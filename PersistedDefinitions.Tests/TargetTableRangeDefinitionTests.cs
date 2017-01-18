using Excello.PersistedDefinitions.Destination;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Excello.PersistedDefinitions.Tests
{
    public class TargetTableRangeDefinitionTests
    {
        [Fact]
        public void TargetTableRangeDefinitionTestFormatOffsetAndColumnCount()
        {
            var inputString = Properties.Resources.DestinationCorrect;

            // act
            var definitionDto = JsonConvert.DeserializeObject<TargetTableRangeDefinition>(inputString);

            // assert
            definitionDto.RowRangeFormat.Should().Be("Correct$A{0}:X{0}");
            definitionDto.DocumentFirstRowOffset.Should().Be(2);
            definitionDto.Columns.Count.Should().Be(3);
        }

        [Fact]
        public void TargetTableRangeDefinitionTestColumnOrdinal()
        {
            var inputString = Properties.Resources.DestinationCorrect;

            // act
            var definitionDto = JsonConvert.DeserializeObject<TargetTableRangeDefinition>(inputString);

            // assert
            definitionDto.Columns[0].Ordinal.Should().Be(1);
            definitionDto.Columns[1].Ordinal.Should().Be(2);
            definitionDto.Columns[2].Ordinal.Should().Be(5);
        }

        [Fact]
        public void TargetTableRangeDefinitionTestColumnName()
        {
            var inputString = Properties.Resources.DestinationCorrect;

            // act
            var definitionDto = JsonConvert.DeserializeObject<TargetTableRangeDefinition>(inputString);

            // assert
            definitionDto.Columns[0].Name.Should().Be("Secname");
            definitionDto.Columns[1].Name.Should().Be("Name");
            definitionDto.Columns[2].Name.Should().Be("Passport");
        }

        [Fact]
        public void TargetTableRangeDefinitionTestColumnFormatString()
        {
            var inputString = Properties.Resources.DestinationCorrect;

            // act
            var definitionDto = JsonConvert.DeserializeObject<TargetTableRangeDefinition>(inputString);

            // assert
            definitionDto.Columns[0].FormatString.Should().Be("{0}");
            definitionDto.Columns[1].FormatString.Should().Be("{0}");
            definitionDto.Columns[2].FormatString.Should().Be("{0}");
        }
    }
}
