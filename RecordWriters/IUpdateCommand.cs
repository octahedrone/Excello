using Excello.RecordSources;

namespace Excello.RecordWriters
{
    public interface IUpdateCommand
    {
        void Update(int rowIndex, IEntityDataRecord entityData);

        int Execute();
    }
}