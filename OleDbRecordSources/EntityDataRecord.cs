using System.Collections.Generic;
using Excello.RecordSources;

namespace Excello.OleDbRecordSources
{
    public class EntityDataRecord : IEntityDataRecord
    {
        public readonly Dictionary<string, object> Values;

        public EntityDataRecord() : this(new Dictionary<string, object>())
        {
        }

        public EntityDataRecord(Dictionary<string, object> values)
        {
            Values = values;
            Errors = new HashSet<string>();
        }

        public HashSet<string> Errors { get; private set; }

        public TryGetValueResult TryGetValue(string name, out object value)
        {
            return Values.TryGetValue(name, out value)
                ? TryGetValueResult.Success
                : TryGetValueResult.Absent;
        }
    }
}