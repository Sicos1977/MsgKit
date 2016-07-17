namespace MsgKit.Streams
{
    /// <summary>
    ///     The GUID stream MUST be named "__substg1.0_00020102". It MUST store the property set GUID part of the property name
    ///     of all named properties in the Message object or any of its subobjects, except for those named properties that have
    ///     PS_MAPI or PS_PUBLIC_STRINGS, as described in [MS-OXPROPS] section 1.3.2, as their property set GUID. The GUIDs are 
    ///     stored in the stream consecutively like an array. If there are multiple named properties that have the same property 
    ///     set GUID, then the GUID is stored only once and all the named properties will refer to it by its index.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee220039(v=exchg.80).aspx
    /// </remarks>
    internal sealed class GuidStream
    {
    }
}