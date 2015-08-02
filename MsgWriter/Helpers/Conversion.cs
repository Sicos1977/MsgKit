using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

namespace MsgWriter.Helpers
{
    internal static class Conversion
    {
        #region ObjectToByteArray
        /// <summary>
        ///     Converts an object to an byte array
        /// </summary>
        /// <param name="obj">The object to convert</param>
        /// <returns></returns>
        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }
        #endregion

        #region ByteArrayToObject
        /// <summary>
        ///     Converts a byte array to an Object
        /// </summary>
        /// <param name="array">The byte array</param>
        /// <returns></returns>
        public static Object ByteArrayToObject(byte[] array)
        {
            using (var memmoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                memmoryStream.Write(array, 0, array.Length);
                memmoryStream.Seek(0, SeekOrigin.Begin);
                return binaryFormatter.Deserialize(memmoryStream);
            }
        }
        #endregion
    }
}
