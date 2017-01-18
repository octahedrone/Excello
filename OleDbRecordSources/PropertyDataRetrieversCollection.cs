using System.Collections;
using System.Collections.Generic;

namespace Excello.OleDbRecordSources
{
    public class PropertyDataRetrieversCollection : IPropertyDataRetrieversCollection,
        IEnumerable<IPropertyDataRetriever>
    {
        private readonly Dictionary<string, IPropertyDataRetriever> _retrievers;

        public PropertyDataRetrieversCollection()
        {
            _retrievers = new Dictionary<string, IPropertyDataRetriever>();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return _retrievers.Keys.GetEnumerator();
        }

        public bool TryGet(string name, out IPropertyDataRetriever retriever)
        {
            return _retrievers.TryGetValue(name, out retriever);
        }

        public IEnumerator<IPropertyDataRetriever> GetEnumerator()
        {
            return _retrievers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IPropertyDataRetriever retriever)
        {
            _retrievers.Add(retriever.Name, retriever);
        }
    }
}