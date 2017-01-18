using System.Collections.Generic;

namespace Excello.RecordSources
{
    public interface IEntityDataRecord
    {
        HashSet<string> Errors { get; }

        TryGetValueResult TryGetValue(string name, out object value);
    }
}