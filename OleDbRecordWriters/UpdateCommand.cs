using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Excello.RecordSources;
using Excello.RecordWriters;

namespace Excello.OleDbRecordWriters
{
    public class UpdateCommand : IUpdateCommand
    {
        private readonly OleDbCommand _command;
        private readonly string _commandTextTemplate;
        private readonly Dictionary<string, int> _bagToCommandParamMapping;

        public UpdateCommand(OleDbCommand command,
            string commandTextTemplate,
            Dictionary<string, int> bagToCommandParamMapping)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (bagToCommandParamMapping == null) throw new ArgumentNullException("bagToCommandParamMapping");

            _command = command;
            _commandTextTemplate = commandTextTemplate;
            _bagToCommandParamMapping = bagToCommandParamMapping;
        }

        public int RowOffset { get; set; }

        public void Update(int rowIndex, IEntityDataRecord entityData)
        {
            rowIndex += RowOffset;

            _command.CommandText = String.Format(_commandTextTemplate, rowIndex);

            foreach (var mapping in _bagToCommandParamMapping)
            {
                var param = _command.Parameters[mapping.Value];

                object value;
                param.Value = (entityData.TryGetValue(mapping.Key, out value) == TryGetValueResult.Success)
                    ? value.ToString()
                    : "";
            }
        }

        public int Execute()
        {
            return _command.ExecuteNonQuery();
        }
    }
}