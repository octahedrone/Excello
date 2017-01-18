namespace Excello.OleDbRecordSources.Reader
{
    public interface IRowsCollectionReaderFactory
    {
        IRowsCollectionReader CreateReader();
    }
}