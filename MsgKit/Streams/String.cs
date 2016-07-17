namespace MsgKit.Streams
{
    /// <summary>
    ///     The string stream MUST be named "__substg1.0_00040102". It MUST consist of one entry for each string named
    ///     property, and all entries MUST be arranged consecutively, like in an array. As specified in section 2.2.3.1.2, 
    ///     the offset, in bytes, to use for a particular property is stored in the corresponding entry in the entry stream.
    ///     That is a byte offset into the string stream from where the entry for the property can be read.The strings MUST 
    ///     NOT be null-terminated. Implementers can add a terminating null character to the string after they read it from 
    ///     the stream, if one is required by the implementer's programming language.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee124409(v=exchg.80).aspx
    /// </remarks>
    internal sealed class String
    {
    }
}