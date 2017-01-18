namespace Excello.OleDbRecordSources
{
    public class PropertyDataRetriever : IPropertyDataRetriever
    {
        public PropertyDataRetriever(string name, IRowValueRetriever retriever)
        {
            Name = name;
            Retriever = retriever;
        }

        public string Name { get; private set; }

        public IRowValueRetriever Retriever { get; private set; }
    }
}