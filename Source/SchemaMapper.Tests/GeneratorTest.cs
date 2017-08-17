using System;
using System.Collections.Generic;
using System.IO;
using CodeSmith.Engine.Json;
using Newtonsoft.Json;
using SchemaExplorer;
using SchemaExplorer.Serialization;
using Xunit;

namespace SchemaMapper.Tests
{
    public class GeneratorTest
    {
        [Fact]
        public void GenerateTrackerDatabaseTest()
        {
            var selector = GetDatabaseSchema("Tracker");
            Assert.NotNull(selector);
            var generator = new Generator();
            EntityContext entityContext = generator.Generate(selector);

            Assert.NotNull(entityContext);

        }

        [Fact]
        public void GenerateUglyDatabaseTest()
        {
            var selector = GetDatabaseSchema("Ugly");
            Assert.NotNull(selector);

            var generator = new Generator();
            EntityContext entityContext = generator.Generate(selector);

            Assert.NotNull(entityContext);
        }

        [Fact]
        public void GeneratePetshopDatabaseTest()
        {
            var selector = GetDatabaseSchema("Petshop");
            Assert.NotNull(selector);

            var generator = new Generator();
            EntityContext entityContext = generator.Generate(selector);

            Assert.NotNull(entityContext);

        }

        [Fact]
        public void GeneratePetshopInclusionModeTest()
        {
            var selector = GetDatabaseSchema("Petshop");
            Assert.NotNull(selector);

            selector.SelectMode = SelectMode.Include;
            selector.SelectedTables.Add("dbo.Account");
            selector.SelectedTables.Add("dbo.Product");
            selector.SelectedTables.Add("dbo.Category");

            selector.SelectedColumns.Add("dbo.Product.Category");

            selector.ColumnExpressions.Add(@"(ID|Id)$");
            selector.ColumnExpressions.Add(@"Name$");

            var generator = new Generator();
            generator.Settings.TableNaming = TableNaming.Singular;
            generator.Settings.EntityNaming = EntityNaming.Singular;
            generator.Settings.RelationshipNaming = RelationshipNaming.Plural;
            generator.Settings.ContextNaming = ContextNaming.Plural;

            var cleanExpressions = new List<string>
            {
                "^(sp|tbl|udf|vw)_"
            };

            foreach (string s in cleanExpressions)
                if (!string.IsNullOrEmpty(s))
                    generator.Settings.CleanExpressions.Add(s);


            EntityContext entityContext = generator.Generate(selector);

            Assert.NotNull(entityContext);
        }


        private SchemaSelector GetDatabaseSchema(string name)
        {
            var databaseSchema = DatabaseSchemaSerializer.GetDatabaseSchemaFromName(name);

            var selector = new SchemaSelector(databaseSchema.Provider, databaseSchema.ConnectionString);
            selector.Database.DeepLoad = true;

            return selector;
        }

    }
}
