using System.Collections.Generic;

namespace Excello.OleDbRecordSources
{
    public interface IPropertyDataRetrieversCollection : IEnumerable<string>
    {
        bool TryGet(string name, out IPropertyDataRetriever retriever);
    }
}