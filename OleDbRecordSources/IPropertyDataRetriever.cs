namespace Excello.OleDbRecordSources
{
    public interface IPropertyDataRetriever
    {
        string Name { get; }

        IRowValueRetriever Retriever { get; }
    }
}