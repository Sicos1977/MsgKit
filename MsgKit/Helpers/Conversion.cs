//
// Conversion.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2021 Magic-Sessions. (www.magic-sessions.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MsgKit.Helpers
{
    /// <summary>
    ///     This class contains conversion related helper methods
    /// </summary>
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
