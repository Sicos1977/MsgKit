//
// CharBuffer.cs
//
// Author: Jeffrey Stedfast <jestedfa@microsoft.com>
//
// Copyright (c) 2015-2023 Jeffrey Stedfast <jestedfa@microsoft.com>
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
using System.Runtime.CompilerServices;

namespace MsgKit.HtmParser
{
    internal class CharBuffer
    {
        #region Fields
        private char[] _buffer;
        #endregion

        #region Constructor
        public CharBuffer(int capacity)
        {
            _buffer = new char[capacity];
        }
        #endregion

        #region Length
        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }
        #endregion

        #region Index
        public char this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _buffer[index];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _buffer[index] = value;
        }
        #endregion

        #region EnsureCapacity
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EnsureCapacity(int length)
        {
            if (length < _buffer.Length)
                return;

            var capacity = _buffer.Length << 1;
            while (capacity <= length)
                capacity <<= 1;

            Array.Resize(ref _buffer, capacity);
        }
        #endregion

        #region Append
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(char c)
        {
            EnsureCapacity(Length + 1);
            _buffer[Length++] = c;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(string str)
        {
            EnsureCapacity(Length + str.Length);
            str.CopyTo(0, _buffer, Length, str.Length);
            Length += str.Length;
        }
        #endregion

        #region ToString
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return new string(_buffer, 0, Length);
        }
        #endregion
    }
}