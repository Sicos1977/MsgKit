//
// HtmlAttributeCollection.cs
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
using System.Collections;
using System.Collections.Generic;
// ReSharper disable UnusedMember.Global

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     A readonly collection of HTML attributes.
    /// </summary>
    /// <remarks>
    ///     A readonly collection of HTML attributes.
    /// </remarks>
    internal class HtmlAttributeCollection : IEnumerable<HtmlAttribute>
    {
        #region Fields
        /// <summary>
        ///     An empty attribute collection.
        /// </summary>
        /// <remarks>
        ///     An empty attribute collection.
        /// </remarks>
        public static readonly HtmlAttributeCollection Empty = new HtmlAttributeCollection();

        private readonly List<HtmlAttribute> _attributes;
        #endregion

        #region Properties
        /// <summary>
        ///     Get the <see cref="HtmlAttribute" /> at the specified index.
        /// </summary>
        /// <remarks>
        ///     Gets the <see cref="HtmlAttribute" /> at the specified index.
        /// </remarks>
        /// <value>The HTML attribute at the specified index.</value>
        /// <param name="index">The index.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> is out of range.
        /// </exception>
        public HtmlAttribute this[int index] => _attributes[index];

        /// <summary>
        ///     Get the number of attributes in the collection.
        /// </summary>
        /// <remarks>
        ///     Gets the number of attributes in the collection.
        /// </remarks>
        /// <value>The number of attributes in the collection.</value>
        public int Count => _attributes.Count;
        #endregion

        #region Constructors
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlAttributeCollection" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlAttributeCollection" />.
        /// </remarks>
        /// <param name="collection">A collection of attributes.</param>
        public HtmlAttributeCollection(IEnumerable<HtmlAttribute> collection)
        {
            _attributes = new List<HtmlAttribute>(collection);
        }

        internal HtmlAttributeCollection()
        {
            _attributes = new List<HtmlAttribute>();
        }
        #endregion

        #region Add
        internal void Add(HtmlAttribute attribute)
        {
            if (attribute is null)
                throw new ArgumentNullException(nameof(attribute));

            _attributes.Add(attribute);
        }
        #endregion

        #region Contains
        /// <summary>
        ///     Check if an attribute exists.
        /// </summary>
        /// <remarks>
        ///     Checks if an attribute exists.
        /// </remarks>
        /// <param name="id">The attribute.</param>
        /// <returns><c>true</c> if the attribute exists within the collection; otherwise, <c>false</c>.</returns>
        public bool Contains(HtmlAttributeId id)
        {
            return IndexOf(id) != -1;
        }

        /// <summary>
        ///     Check if an attribute exists.
        /// </summary>
        /// <remarks>
        ///     Checks if an attribute exists.
        /// </remarks>
        /// <param name="name">The name of the attribute.</param>
        /// <returns><c>true</c> if the attribute exists within the collection; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="name" /> is <c>null</c>.
        /// </exception>
        public bool Contains(string name)
        {
            return IndexOf(name) != -1;
        }
        #endregion

        #region IndexOf
        /// <summary>
        ///     Get the index of a desired attribute.
        /// </summary>
        /// <remarks>
        ///     Gets the index of a desired attribute.
        /// </remarks>
        /// <param name="id">The attribute.</param>
        /// <returns><c>true</c> if the attribute exists within the collection; otherwise, <c>false</c>.</returns>
        public int IndexOf(HtmlAttributeId id)
        {
            for (var i = 0; i < _attributes.Count; i++)
                if (_attributes[i].Id == id)
                    return i;

            return -1;
        }

        /// <summary>
        ///     Get the index of a desired attribute.
        /// </summary>
        /// <remarks>
        ///     Gets the index of a desired attribute.
        /// </remarks>
        /// <param name="name">The name of the attribute.</param>
        /// <returns><c>true</c> if the attribute exists within the collection; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="name" /> is <c>null</c>.
        /// </exception>
        public int IndexOf(string name)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            for (var i = 0; i < _attributes.Count; i++)
                if (_attributes[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return i;

            return -1;
        }
        #endregion

        #region TryGetValue
        /// <summary>
        ///     Get an attribute from the collection if it exists.
        /// </summary>
        /// <remarks>
        ///     Gets an attribute from the collection if it exists.
        /// </remarks>
        /// <param name="id">The id of the attribute.</param>
        /// <param name="attribute">The attribute if found; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the desired attribute is found; otherwise, <c>false</c>.</returns>
        public bool TryGetValue(HtmlAttributeId id, out HtmlAttribute attribute)
        {
            int index;

            if ((index = IndexOf(id)) == -1)
            {
                attribute = null;
                return false;
            }

            attribute = _attributes[index];

            return true;
        }

        /// <summary>
        ///     Get an attribute from the collection if it exists.
        /// </summary>
        /// <remarks>
        ///     Gets an attribute from the collection if it exists.
        /// </remarks>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="attribute">The attribute if found; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the desired attribute is found; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="name" /> is <c>null</c>.
        /// </exception>
        public bool TryGetValue(string name, out HtmlAttribute attribute)
        {
            int index;

            if ((index = IndexOf(name)) == -1)
            {
                attribute = null;
                return false;
            }

            attribute = _attributes[index];

            return true;
        }
        #endregion

        #region GetEnumerator
        /// <summary>
        ///     Get an enumerator for the attribute collection.
        /// </summary>
        /// <remarks>
        ///     Gets an enumerator for the attribute collection.
        /// </remarks>
        /// <returns>The enumerator.</returns>
        public IEnumerator<HtmlAttribute> GetEnumerator()
        {
            return _attributes.GetEnumerator();
        }

        /// <summary>
        ///     Get an enumerator for the attribute collection.
        /// </summary>
        /// <remarks>
        ///     Gets an enumerator for the attribute collection.
        /// </remarks>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _attributes.GetEnumerator();
        }
        #endregion
    }
}