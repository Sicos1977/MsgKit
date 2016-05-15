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

namespace MsgWriter
{
    /// <summary>
    ///     A process that converts PropertyName structures to property IDs and vice-versa. Named properties can be referred to
    ///     by their PropertyName. However, before accessing the property on a specific message store, named properties need to
    ///     be mapped to property IDs that are valid for that message store. The reverse is also true. When properties need to
    ///     be copied across message stores, property IDs that are valid for the source message store need to be mapped to
    ///     their PropertyName structures before they can be sent to the destination message store.
    /// </summary>
    internal class NamedPropertyMapping
    {
        /*
        3.2.1.1 Fetching the Name Identifier
         * 
        In this example, property ID 0x8005 has to be mapped to its property name. First, the entry index into the entry stream (1) is determined:
        Property ID – 0x8000
        =0x8005 – 0x8000
        =0x0005
        Then, the offset for the corresponding 8-byte entry is determined:
        Entry index * size of entry
        = 0x05 * 0x08
        = 0x28
        The offset is then used to fetch the entry from the entry stream (1) ("__substg1.0_00030102"), which is contained inside the named property 
        mapping storage ("__nameid_version1.0"). In this case, bytes 40 – 47 are fetched from the stream (1). Then, the structure specified in the 
        entry stream (1) section is applied to those bytes, taking into consideration that the data is stored in little-endian format.
           
         */
    }
}