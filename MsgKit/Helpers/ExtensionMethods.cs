using OpenMcdf;

namespace MsgKit.Helpers;

internal static class ExtensionMethods
{
    /// <summary>
    ///     Gets the storage or creates it when it not exist
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="name">The name of the storage</param>
    /// <returns></returns>
    internal static Storage GetStorage(this Storage storage, string name) 
    {
        return storage.TryOpenStorage(name, out var st) ? st : storage.CreateStorage(name);
    }

    /// <summary>
    ///     Gets the stream or creates it when it not exist
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="name">The name of the storage</param>
    /// <returns></returns>
    internal static CfbStream GetStream(this Storage storage, string name) 
    {
        return storage.TryOpenStream(name, out var st) ? st : storage.CreateStream(name);
    }
}