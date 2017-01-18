using System.Collections.Generic;

namespace Excello.RecordSources
{
    public interface IDataRecordSource
    {
        IEnumerable<IEntityDataRecord> GetRecords();
    }
}