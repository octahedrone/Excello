namespace Excello.OleDbRecordSources.Reader
{
    public interface IRowsCollectionReader : IRowDataReader
    {
        bool MoveNext();

        void Close();
    }
}