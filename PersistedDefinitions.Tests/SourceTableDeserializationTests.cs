using Excello.PersistedDefinitions.Source;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Excello.PersistedDefinitions.Tests
{
    public class SourceTableDeserializationTests
    {
        [Fact]
        public void SourceTableDeserializationTestsRangeAndCount()
        {
            var inputString = Properties.Resources.SourceFile;
            
            // act
            var definitionDto = JsonConvert.DeserializeObject<SourceTableRangeDefinition>(inputString);

            // assert
            definitionDto.Range.Should().Be("Sheet1$A3:X100");
            definitionDto.Columns.Count.Should().Be(3);
        }

        [Fact]
        public void SourceTableDeserializationTestsSourceOrdinal()
        {
            var inputString = Properties.Resources.SourceFile;

            //act
            var definitionDto = JsonConvert.DeserializeObject<SourceTableRangeDefinition>(inputString);

            // assert
            definitionDto.Columns[0].SourceOrdinal.Should().Be(1);
            definitionDto.Columns[1].SourceOrdinal.Should().Be(2);
            definitionDto.Columns[2].SourceOrdinal.Should().Be(5);
        }

        [Fact]
        public void SourceTableDeserializationTestsName()
        {
            var inputString = Properties.Resources.SourceFile;

            //act
            var definitionDto = JsonConvert.DeserializeObject<SourceTableRangeDefinition>(inputString);

            // assert
            definitionDto.Columns[0].Name.Should().Be("Secname");
            definitionDto.Columns[1].Name.Should().Be("Name");
            definitionDto.Columns[2].Name.Should().Be("Passport");
        }

        [Fact]
        public void SourceTableDeserializationTestsFinalType()
        {
            var inputString = Properties.Resources.SourceFile;

            //act
            var definitionDto = JsonConvert.DeserializeObject<SourceTableRangeDefinition>(inputString);

            // assert
            definitionDto.Columns[0].FinalType.Should().Be("string");
            definitionDto.Columns[1].FinalType.Should().Be("string");
            definitionDto.Columns[2].FinalType.Should().Be("string");
        }
    }
}
