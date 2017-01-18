using System.Data.OleDb;
using System.IO;

namespace Excello.OleDbRecordSources
{
    public static class ExcelConnectionProviderFactory
    {
        public static OleDbConnection Connect(this string workbookPath)
        {
            var extension = Path.GetExtension(workbookPath);
            // connection string depends on workbook file extension
            const string connectionStringPatternXls =
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=No;IMAX=1;Readonly=False;\"";

            const string connectionStringPatternXlsx =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=No;IMAX=1;Readonly=False;\"";

            var connectionSting = extension == ".xls" 
                ? string.Format(connectionStringPatternXls, workbookPath)
                : string.Format(connectionStringPatternXlsx, workbookPath);

            return new OleDbConnection(connectionSting);
        }
    }
}