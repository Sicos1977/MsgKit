//
// OptimizedOrdinalComparer.cs
//
// Author: Jeffrey Stedfast <jestedfa@microsoft.com>
//
// Copyright (c) 2013-2023 Jeffrey Stedfast <jestedfa@microsoft.com>
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
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An optimized version of StringComparer.OrdinalIgnoreCase.
    /// </summary>
    /// <remarks>
    ///     An optimized version of <see cref="StringComparer.OrdinalIgnoreCase">StringComparer.OrdinalIgnoreCase</see>.
    /// </remarks>
    internal sealed class OptimizedOrdinalIgnoreCaseComparer : IEqualityComparer<string>
    {
        public static readonly IEqualityComparer<string> Comparer = new OptimizedOrdinalIgnoreCaseComparer();

        #region Constructor
        /// <summary>
        ///     Initializes a new instance of the <see cref="OptimizedOrdinalIgnoreCaseComparer" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="OptimizedOrdinalIgnoreCaseComparer" />.
        /// </remarks>
        public OptimizedOrdinalIgnoreCaseComparer()
        {
        }
        #endregion

        #region ToUpper
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int ToUpper(int c)
        {
            // check if the char is within the lowercase range
            if ((uint)(c - 'a') <= 'z' - 'a')
                return c - 0x20;

            return c;
        }
        #endregion

        #region Equals
        /// <summary>
        ///     Compare the input strings for equality.
        /// </summary>
        /// <remarks>
        ///     Compares the input strings for equality.
        /// </remarks>
        /// <returns>
        ///     <c>true</c>if <paramref name="x" /> and <paramref name="y" /> refer to the same object,
        ///     or <paramref name="x" /> and <paramref name="y" /> are equal,
        ///     or <paramref name="x" /> and <paramref name="y" /> are <c>null</c>;
        ///     otherwise, <c>false</c>.
        /// </returns>
        /// <param name="x">A string to compare to <paramref name="y" />.</param>
        /// <param name="y">A string to compare to <paramref name="x" />.</param>
        public bool Equals(string x, string y)
        {
            if (x== null)
                throw new ArgumentNullException(nameof(x));

            if (y== null)
                throw new ArgumentNullException(nameof(y));

            if (x.Length != y.Length)
                return false;

            var length = x.Length;
            for (var i = 0; i < length; i++)
                if (ToUpper(x[i]) != ToUpper(y[i]))
                    return false;

            return true;
        }
        #endregion

        #region GetHashCode
        /// <summary>
        ///     Get the hash code for the specified string.
        /// </summary>
        /// <remarks>
        ///     Get the hash code for the specified string.
        /// </remarks>
        /// <returns>A 32-bit signed hash code calculated from the value of the <paramref name="obj" /> parameter.</returns>
        /// <param name="obj">The string.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="obj" /> is <c>null</c>.
        /// </exception>
        public int GetHashCode(string obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return obj.GetHashCode();
        }
        #endregion
    }
}