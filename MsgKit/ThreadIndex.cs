using System;
using System.Linq;

namespace MsgKit
{
    /// <summary>
    ///     Identifies a particular conversation thread; computed from message references.
    /// </summary>
    public class ThreadIndex
    {
        #region Properties
        /// <summary>
        ///     The date and time
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        ///     The unique GUID for this thread
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        ///     The RAW base64 encoded thread index
        /// </summary>
        public string Raw { get; }

        /// <summary>
        ///     Returns <c>true</c> when the thread index is valid
        /// </summary>
        public bool IsValid
        {
            get { return Date != default(DateTime) && Id != default(Guid); }
        }
        #endregion
        
        #region Constructor
        /// <summary>
        ///     Creates this object and parses the given <paramref name="threadIndex" />
        /// </summary>
        /// <param name="threadIndex"></param>
        public ThreadIndex(string threadIndex)
        {
            Raw = threadIndex;

            var bytes = Convert.FromBase64String(threadIndex);

            // Thread index length should be 22 plus extra 5 bytes per reply
            if (bytes.Length < 22 || (bytes.Length - 22)%5 != 0)
                return;

            Id = new Guid(bytes.Skip(6).Take(16).ToArray());

            var headerTicks = bytes
                .Take(6)
                .Select(b => (long) b)
                .Aggregate((l1, l2) => (l1 << 8) + l2)
                              << 16;

            Date = new DateTime(headerTicks, DateTimeKind.Utc).AddYears(1600);

            var childBlockCount = (bytes.Length - 22)/5;

            for (var i = 0; i < childBlockCount; i++)
            {
                var childTicks = bytes
                    .Skip(22 + i*5).Take(4)
                    .Select(b => (long) b)
                    .Aggregate((l1, l2) => (l1 << 8) + l2)
                                 << 18;

                childTicks &= ~((long) 1 << 50);
                Date = Date.AddTicks(childTicks);
            }
        }
        #endregion

        #region ToString
        /// <summary>
        ///     Returns the information about this thread index as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id}, Date: {Date.ToLocalTime()}";
        }
        #endregion
    }
}