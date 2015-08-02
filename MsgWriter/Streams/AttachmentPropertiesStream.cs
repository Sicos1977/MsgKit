using System.IO;

/*
   Copyright 2015 Kees van Spelde

   Licensed under The Code Project Open License (CPOL) 1.02;
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.codeproject.com/info/cpol10.aspx

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace MsgWriter.Streams
{
    /// <summary>
    ///     The properties stream contained inside an Attachment storage object
    /// </summary>
    internal sealed class AttachmentPropertiesStream : Properties
    {
        #region FromByteArray
        /// <summary>
        ///     Reads the property stream contained inside an Attachment object storage or a Recipient 
        ///     object storage
        /// </summary>
        /// <param name="byteArray"></param>
        internal void FromByteArray(byte[] byteArray)
        {
            using (var memoryStream = new MemoryStream(byteArray))
            using (var binaryReader = new BinaryReader(memoryStream))
            {
                binaryReader.ReadBytes(8);
                ReadProperties(binaryReader);
            }
        }
        #endregion

        #region ToByteArray
        /// <summary>
        ///     Returns the property stream contained inside an Attachment object storage or a Recipient 
        ///     object storage as a byte array
        /// </summary>
        /// <returns></returns>
        internal byte[] ToByteArray()
        {
            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                binaryWriter.Write(new byte[8]);
                //WriteProperties(binaryWriter);
                return memoryStream.ToArray();
            }
        }
        #endregion
    }
}
