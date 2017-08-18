using System;
using System.IO;
using Newtonsoft.Json;
using SchemaExplorer;

namespace SchemaMapper.Tests
{
    public abstract class TestBase
    {
        protected SchemaSelector GetDatabaseSchema(string databaseName)
        {
            var connectionString = $"Data Source=(local);Initial Catalog={ databaseName };Integrated Security=True";
            var provider = new SqlSchemaProvider();

            return GetDatabaseSchema(provider, connectionString);
        }

        protected SchemaSelector GetDatabaseSchema(IDbSchemaProvider provider, string connectionString)
        {
            var selector = new SchemaSelector(provider, connectionString);
            selector.Database.DeepLoad = true;

            return selector;
        }

        protected void SaveAsJson(object instance, string path)
        {
            var settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(instance, settings);
            File.WriteAllText(path, json);
        }
    }
}