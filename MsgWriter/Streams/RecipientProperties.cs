using System.IO;
using MsgKit.Structures;
using OpenMcdf;

/*
   Copyright 2015 - 2016 Kees van Spelde

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

namespace MsgKit.Streams
{
    /// <summary>
    ///     The properties stream contained inside an Recipient storage object.
    /// </summary>
    internal sealed class RecipientProperties : Properties
    {
        #region ReadProperties
        /// <summary>
        ///     Reads all the <see cref="Property">properties</see> from the <see cref="CFStream"/>
        /// </summary>
        /// <param name="stream">The <see cref="CFStream"/></param>
        internal void ReadProperties(CFStream stream)
        {
            using (var memoryStream = new MemoryStream(stream.GetData()))
            using (var binaryReader = new BinaryReader(memoryStream))
            {
                binaryReader.ReadBytes(8);
                ReadProperties(binaryReader);
            }
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all <see cref="Property">properties</see> either as a <see cref="CFStream"/> or as a collection in
        ///     a <see cref="PropertyTags.PropertiesStreamName"/> stream to the given <see cref="storage"/>, this depends 
        ///     on the <see cref="MsgKit.Enums.PropertyType"/>
        /// </summary>
        /// <remarks>
        ///     See the <see cref="Properties"/> class it's <see cref="Properties.WriteProperties"/> method for the logic
        ///     that is used to determine this
        /// </remarks>
        /// <param name="storage">The <see cref="CFStorage"/></param>
        /// <returns>
        ///     Total size of the written <see cref="Properties"/>
        /// </returns>
        internal long WriteProperties(CFStorage storage)
        {
            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                // Reserved (8 bytes): This field MUST be set to zero when writing a .msg file and MUST be ignored when reading a .msg file.
                binaryWriter.Write(new byte[8]);
                return WriteProperties(storage, binaryWriter);
            }
        }
        #endregion
    }
}
