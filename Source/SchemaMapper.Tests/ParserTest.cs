using System;
using System.Xml;
using System.Xml.Serialization;
using SchemaExplorer;
using SchemaExplorer.Serialization;
using Xunit;

namespace SchemaMapper.Tests
{
    public class ParserTest : TestBase
    {
        [Fact]
        public void ParseContext()
        {
            string contextFile = @"..\..\..\..\Samples\Tracker.Data\TrackerContext.Generated.cs";
            var result = ContextParser.Parse(contextFile);

            Assert.NotNull(result);
            SaveAsJson(result, $"..\\..\\..\\TrackerContext.Generated-{DateTime.Now:yyyy-dd-M--HH-mm-ss}.json");
        }

        [Fact]
        public void ParseMapping()
        {
            string mappingFile = @"..\..\..\..\Samples\Tracker.Data\Mapping\TaskMap.Generated.cs";

            var result = MappingParser.Parse(mappingFile);
            Assert.NotNull(result);
            SaveAsJson(result, $"..\\..\\..\\TaskMap.Generated-{DateTime.Now:yyyy-dd-M--HH-mm-ss}.json");
        }

        [Fact]
        public void ParseManyToManyMapping()
        {
            string mappingFile = @"..\..\..\..\Samples\Tracker.Data\Mapping\RoleMap.Generated.cs";

            var result = MappingParser.Parse(mappingFile);
            Assert.NotNull(result);
            SaveAsJson(result, $"..\\..\\..\\RoleMap.Generated-{DateTime.Now:yyyy-dd-M--HH-mm-ss}.json");
        }

        [Fact]
        public void ParseTwoForeignKeyMapping()
        {
            string mappingFile = @"..\..\..\Ugly.Data\Mapping\TwoForeignKeyMap.Generated.cs";

            var result = MappingParser.Parse(mappingFile);
            Assert.NotNull(result);
            SaveAsJson(result, $"..\\..\\..\\TwoForeignKeyMap.Generated-{DateTime.Now:yyyy-dd-M--HH-mm-ss}.json");
        }


        [Fact]
        public void ParseTracker()
        {
            var generator = new Generator();
            generator.Settings.ContextNaming = ContextNaming.Preserve;
            generator.Settings.EntityNaming = EntityNaming.Singular;
            generator.Settings.RelationshipNaming = RelationshipNaming.ListSuffix;
            generator.Settings.TableNaming = TableNaming.Singular;

            var selector = GetDatabaseSchema("Tracker");
            Assert.NotNull(selector);

            EntityContext entityContext = generator.Generate(selector);

            Assert.NotNull(entityContext);

            //var settings = new XmlWriterSettings { Indent = true };
            //var serializer = new XmlSerializer(typeof(EntityContext));

            //using (var writer = XmlWriter.Create(@"..\..\Tracker.Generated.xml", settings))
            //    serializer.Serialize(writer, entityContext);

            string contextDirectory = @"..\..\..\..\Samples\Tracker.Data";
            string mappingDirectory = @"..\..\..\..\Samples\Tracker.Data\Mapping";

            Synchronizer.UpdateFromSource(entityContext, contextDirectory, mappingDirectory);

            //using (var writer = XmlWriter.Create(@"..\..\Tracker.Updated.xml", settings))
            //    serializer.Serialize(writer, entityContext);
        }
    }
}