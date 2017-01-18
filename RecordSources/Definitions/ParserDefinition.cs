using System;

namespace Excello.RecordSources.Definitions
{
    public struct ParserDefinition
    {
        public Type FinalType { get; set; }

        public string[] ParsingFormats { get; set; }
    }
}