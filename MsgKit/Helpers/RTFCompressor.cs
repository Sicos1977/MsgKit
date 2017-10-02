using System;
using System.IO;
using System.Text;

namespace MsgKit.Helpers
{
    /// <summary>
    /// Used to compress RTF using LZFu by Microsoft.  Can be viewed in the [MS-OXRTFCP].pdf document. 
    /// https://msdn.microsoft.com/en-us/library/cc463890(v=exchg.80).aspx
    /// </summary>
    internal static class RTFCompressor
    {
        #region CompressionPosition Class
        /// <summary>
        /// Holder for compression positions, aren't relevent to other parts of the project thus inside of RTFCompressor class. 
        /// </summary>
        internal class CompressionPositions
        {
            public int DictionaryOffset { get; set; }
            public int LongestMatchLength;
            public int WriteOffset { get; set; }
        }
        #endregion

        #region Fields
        public const int INIT_DICT_SIZE = 207;
        public const int MAX_DICT_SIZE = 4096;
        public const string COMP_TYPE = "LZFu";

        static byte[] InitialDictionary;
        #endregion

        #region FindLongestMatch
        /// <summary>
        /// Helper function
        /// </summary>
        /// <param name="initialDictionary">Part of the MS-OXRTFCP spec. </param>
        /// <param name="streamReader">BinaryReader which is pointing at the input data. </param>
        /// <param name="writeOffset">Write offset</param>
        /// <returns> CompressionPositions class containing DictionaryOffset, LongestMatchLength, WriteOffset</returns>
        static internal CompressionPositions FindLongestMatch(byte[] initialDictionary, BinaryReader streamReader, int writeOffset)
        {
            var chardict = Encoding.UTF8.GetString(initialDictionary).ToCharArray();
            var readCharacter = streamReader.Read();
            var positionData = new CompressionPositions() { WriteOffset = writeOffset };
            if (readCharacter == -1)
                return positionData;

            var previousWriteOffset = writeOffset;
            var matchLength = 0;
            var dictionaryIndex = 0;

            while (true)
            {
                if (initialDictionary[dictionaryIndex] == readCharacter)
                {
                    if (++matchLength <= 17 && matchLength > positionData.LongestMatchLength)
                    {
                        positionData.DictionaryOffset = dictionaryIndex - matchLength + 1;
                        initialDictionary[positionData.WriteOffset] = Convert.ToByte(readCharacter);
                        positionData.WriteOffset = (positionData.WriteOffset + 1) % MAX_DICT_SIZE;
                        positionData.LongestMatchLength = matchLength;
                    }

                    if ((readCharacter = streamReader.Read()) == -1)
                    {
                        streamReader.BaseStream.Seek(streamReader.BaseStream.Position - matchLength, SeekOrigin.Begin);
                        return positionData;
                    }
                }
                else
                {
                    streamReader.BaseStream.Seek(streamReader.BaseStream.Position - matchLength - 1, SeekOrigin.Begin);
                    matchLength = 0;
                    if ((readCharacter = streamReader.Read()) == -1)
                        break;
                }

                if (++dictionaryIndex >= previousWriteOffset + positionData.LongestMatchLength)
                    break;

            }
            streamReader.BaseStream.Seek(streamReader.BaseStream.Position - matchLength - 1, 0);
            return positionData;
        }
        #endregion

        #region Compress
        /// <summary>
        /// Takes in data, compresses it using LZFu. Returns the data as a byte array. 
        /// </summary>
        /// <param name="data">Byte array containing data to be compressed.</param>
        /// <returns>Byte array containing the data that is compressed.</returns>
        static internal byte[] Compress(byte[] data)
        {
            var builder = new StringBuilder();
            builder.Append(@"{\rtf1\ansi\mac\deff0\deftab720{\fonttbl;}");
            builder.Append(@"{\f0\fnil \froman \fswiss \fmodern \fscript ");
            builder.Append(@"\fdecor MS Sans SerifSymbolArialTimes New RomanCourier{\colortbl\red0\green0\blue0");
            builder.Append("\r\n");
            builder.Append(@"\par \pard\plain\f0\fs20\b\i\u\tab\tx");
            InitialDictionary = Encoding.UTF8.GetBytes(builder.ToString());
            Array.Resize(ref InitialDictionary, MAX_DICT_SIZE);

            var positionData = new CompressionPositions() { WriteOffset = INIT_DICT_SIZE };
            var inStream = new MemoryStream(data);
            var binaryReader = new BinaryReader(inStream);
            var controlByte = 0;
            var controlBit = 1;
            var tokenOffset = 0;

            using (MemoryStream outStream = new MemoryStream())
            using (MemoryStream tokenStream = new MemoryStream())
            {
                while (true)
                {
                    var dictReference = 0;
                    positionData = FindLongestMatch(InitialDictionary, binaryReader, positionData.WriteOffset);
                    byte[] readChar;

                    if (binaryReader.PeekChar() < 0)
                    {
                        controlByte |= 1 << controlBit - 1;
                        controlBit++;
                        tokenOffset += 2;
                        dictReference = (positionData.WriteOffset & 0xFFF) << 4;
                        var bytes = BitConverter.GetBytes((ushort)dictReference);
                        Array.Reverse(bytes);
                        tokenStream.Write(bytes, 0, 2);
                        outStream.WriteByte((byte)controlByte);
                        outStream.Write(tokenStream.ToArray(), 0, tokenOffset);
                        break;
                    }

                    readChar = binaryReader.ReadBytes(positionData.LongestMatchLength > 1 ? positionData.LongestMatchLength : 1);
                    if (positionData.LongestMatchLength > 1)
                    {
                        controlByte |= 1 << controlBit - 1;
                        controlBit++;
                        tokenOffset += 2;
                        dictReference = (positionData.DictionaryOffset & 0xFFF) << 4 | (positionData.LongestMatchLength - 2) & 0xf;
                        var bytes = BitConverter.GetBytes((ushort)dictReference);
                        Array.Reverse(bytes);
                        tokenStream.Write(bytes, 0, 2);
                    }
                    else
                    {
                        if (positionData.LongestMatchLength == 0)
                        {
                            InitialDictionary[positionData.WriteOffset] = Convert.ToByte(readChar[0]);
                            positionData.WriteOffset = (positionData.WriteOffset + 1) % MAX_DICT_SIZE;
                        }
                        controlByte |= 0 << controlBit - 1;
                        controlBit++;
                        tokenOffset++;
                        tokenStream.Write(readChar, 0, readChar.Length);
                    }

                    positionData.LongestMatchLength = 0;
                    if (controlBit > 8)
                    {
                        outStream.WriteByte((byte)controlByte);
                        outStream.Write(tokenStream.ToArray(), 0, tokenOffset);
                        controlByte = 0;
                        controlBit = 1;
                        tokenOffset = 0;
                        tokenStream.SetLength(0);
                    }
                }

                var compSize = (uint)outStream.Length + 12;
                var rawSize = (uint)data.Length;
                var crcValue = Crc32Calculator.CalculateCrc32(outStream.ToArray());

                using (var resultStream = new MemoryStream())
                {
                    resultStream.Write(BitConverter.GetBytes(compSize), 0, BitConverter.GetBytes(compSize).Length);
                    resultStream.Write(BitConverter.GetBytes(rawSize), 0, BitConverter.GetBytes(rawSize).Length);
                    resultStream.Write(Encoding.UTF8.GetBytes(COMP_TYPE), 0, Encoding.UTF8.GetBytes(COMP_TYPE).Length);
                    resultStream.Write(BitConverter.GetBytes(crcValue), 0, BitConverter.GetBytes(crcValue).Length);
                    resultStream.Write(outStream.ToArray(), 0, outStream.ToArray().Length);
                    return resultStream.ToArray();
                }
            }
        }
        #endregion
    }
}
