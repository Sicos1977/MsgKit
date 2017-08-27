using OpenMcdf;

namespace MsgKit.Helpers
{
    internal static class Storage
    {
        #region Copy
        /// <summary>
        /// Copies the given <paramref name="source"/> to the given <paramref name="destination"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void Copy(CFStorage source, CFStorage destination)
        {
            source.VisitEntries(action =>
            {
                if (action.IsStorage)
                {
                    var destinationStorage = destination.AddStorage(action.Name);
                    destinationStorage.CLSID = action.CLSID;
                    destinationStorage.CreationDate = action.CreationDate;
                    destinationStorage.ModifyDate = action.ModifyDate;
                    Copy(action as CFStorage, destinationStorage);
                }
                else
                {
                    var sourceStream = action as CFStream;
                    var destinationStream = destination.AddStream(action.Name);
                    if (sourceStream != null) destinationStream.SetData(sourceStream.GetData());
                }

            }, false);
        }
        #endregion
    }
}
