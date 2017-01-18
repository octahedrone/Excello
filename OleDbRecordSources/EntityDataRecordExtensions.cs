using Excello.RecordSources;

namespace Excello.OleDbRecordSources
{
    public static class EntityDataRecordExtensions
    {
        public static bool IsValid(this IEntityDataRecord record)
        {
            return record.Errors.Count == 0;
        }

        public static bool ContainsValueFor(this IEntityDataRecord record, string propertyName)
        {
            object value;
            return record.TryGetValue("Date", out value) == TryGetValueResult.Success;
        }
    }
}