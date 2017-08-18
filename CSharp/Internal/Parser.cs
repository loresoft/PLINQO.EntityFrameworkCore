using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SchemaMapper
{
    #region Mapping Parser
    [DebuggerDisplay("Table: {TableName}, Entity: {EntityClass}, Mapping: {MappingClass}")]
    public class ParsedEntity
    {
        public ParsedEntity()
        {
            Properties = new List<ParsedProperty>();
            Relationships = new List<ParsedRelationship>();
        }

        public string EntityClass { get; set; }
        public string MappingClass { get; set; }

        public string TableName { get; set; }
        public string TableSchema { get; set; }

        public List<ParsedProperty> Properties { get; private set; }
        public List<ParsedRelationship> Relationships { get; private set; }
    }

    [DebuggerDisplay("Column: {ColumnName}, Property: {PropertyName}")]
    public class ParsedProperty
    {
        public string ColumnName { get; set; }
        public string PropertyName { get; set; }
    }

    [DebuggerDisplay("This: {ThisPropertyName}, Other: {OtherPropertyName}")]
    public class ParsedRelationship
    {
        public ParsedRelationship()
        {
            ThisProperties = new List<string>();
        }

        public string ThisPropertyName { get; set; }
        public List<string> ThisProperties { get; private set; }

        public string OtherPropertyName { get; set; }
    }

    public class MappingVisitor : CSharpSyntaxWalker
    {
        private ParsedProperty _currentProperty;
        private ParsedRelationship _currentRelationship;


        public MappingVisitor()
        {
            MappingBaseType = "IEntityTypeConfiguration";
        }

        public string MappingBaseType { get; set; }

        public ParsedEntity ParsedEntity { get; set; }


        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            ParseClassNames(node);
            base.VisitClassDeclaration(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {

            var methodName = ParseMethodName(node);

            switch (methodName)
            {
                case "HasForeignKey":
                    ParseForeignKey(node);
                    break;
                case "WithMany":
                case "WithOne":
                    ParseWithMany(node);
                    break;
                case "HasMany":
                case "HasOne":
                    ParseHasOne(node);
                    break;
                case "HasColumnName":
                    ParseColumnName(node);
                    break;
                case "Property":
                    ParseProperty(node);
                    break;
                case "ToTable":
                    ParseTable(node);
                    break;
            }

            base.VisitInvocationExpression(node);
        }


        private string ParseMethodName(InvocationExpressionSyntax node)
        {
            var memberAccess = node
                .ChildNodes()
                .OfType<MemberAccessExpressionSyntax>()
                .FirstOrDefault();

            if (memberAccess == null)
                return string.Empty;

            var methodName = memberAccess
                .ChildNodes()
                .OfType<IdentifierNameSyntax>()
                .Select(s => s.Identifier.ValueText)
                .LastOrDefault();

            return methodName ?? string.Empty;
        }

        private string ParseLambaExpression(InvocationExpressionSyntax node)
        {
            if (node == null)
                return null;

            var lambaExpression = node
                .ArgumentList
                .DescendantNodes()
                .OfType<LambdaExpressionSyntax>()
                .FirstOrDefault();

            if (lambaExpression == null)
                return null;

            var simpleExpression = lambaExpression
                .DescendantNodes()
                .OfType<MemberAccessExpressionSyntax>()
                .FirstOrDefault();

            if (simpleExpression == null)
                return null;

            var propertyName = simpleExpression
                .DescendantNodes()
                .OfType<IdentifierNameSyntax>()
                .Select(s => s.Identifier.ValueText)
                .LastOrDefault();

            return propertyName;
        }


        private void ParseHasOne(InvocationExpressionSyntax node)
        {
            if (node == null || ParsedEntity == null || _currentRelationship == null)
                return;

            var propertyName = ParseLambaExpression(node);
            _currentRelationship.ThisPropertyName = propertyName;
        }

        private void ParseWithMany(InvocationExpressionSyntax node)
        {
            if (node == null || ParsedEntity == null || _currentRelationship == null)
                return;

            var propertyName = ParseLambaExpression(node);
            _currentRelationship.OtherPropertyName = propertyName;

        }

        private void ParseForeignKey(InvocationExpressionSyntax node)
        {
            if (node == null || ParsedEntity == null)
                return;

            var propertyName = ParseLambaExpression(node);

            _currentRelationship = new ParsedRelationship();
            ParsedEntity.Relationships.Add(_currentRelationship);

            _currentRelationship.ThisProperties.Add(propertyName);
        }

        private void ParseProperty(InvocationExpressionSyntax node)
        {
            if (node == null || _currentProperty == null)
                return;

            var propertyName = ParseLambaExpression(node);

            _currentProperty.PropertyName = propertyName;
            _currentProperty = null;
        }

        private void ParseColumnName(InvocationExpressionSyntax node)
        {
            if (node == null || ParsedEntity == null)
                return;

            var columnName = node
                .ArgumentList
                .DescendantNodes()
                .OfType<LiteralExpressionSyntax>()
                .Select(t => t.Token.ValueText)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(columnName))
                return;

            _currentProperty = new ParsedProperty { ColumnName = columnName };
            ParsedEntity.Properties.Add(_currentProperty);
        }

        private void ParseTable(InvocationExpressionSyntax node)
        {
            if (node == null || ParsedEntity == null)
                return;

            var arguments = node
                .ArgumentList
                .DescendantNodes()
                .OfType<LiteralExpressionSyntax>()
                .Select(t => t.Token.ValueText)
                .ToList();

            if (arguments.Count == 0)
                return;

            if (arguments.Count >= 1)
                ParsedEntity.TableName = arguments[0];

            if (arguments.Count >= 2)
                ParsedEntity.TableSchema = arguments[1];
        }

        private void ParseClassNames(ClassDeclarationSyntax node)
        {
            if (node == null)
                return;

            var baseType = node.BaseList
                .DescendantNodes()
                .OfType<GenericNameSyntax>()
                .FirstOrDefault(t => t.Identifier.ValueText == MappingBaseType);

            if (baseType == null)
                return;

            var firstArgument = baseType
                .TypeArgumentList
                .Arguments
                .FirstOrDefault();

            // last identifier is class name
            var entityClass = firstArgument
                .DescendantNodesAndSelf()
                .OfType<IdentifierNameSyntax>()
                .Select(s => s.Identifier.ValueText)
                .LastOrDefault();

            var mappingClass = node.Identifier.Text;

            if (string.IsNullOrEmpty(entityClass) || string.IsNullOrEmpty(mappingClass))
                return;

            if (ParsedEntity == null)
                ParsedEntity = new ParsedEntity();

            ParsedEntity.MappingClass = mappingClass;
            ParsedEntity.EntityClass = entityClass;
        }
    }

    public static class MappingParser
    {
        public static ParsedEntity Parse(string mappingFile)
        {
            if (string.IsNullOrEmpty(mappingFile) || !File.Exists(mappingFile))
                return null;

            var code = File.ReadAllText(mappingFile);
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = (CompilationUnitSyntax)syntaxTree.GetRoot();

            var visitor = new MappingVisitor();
            visitor.Visit(root);

            var parsedEntity = visitor.ParsedEntity;

            if (parsedEntity != null)
                Debug.WriteLine("Parsed Mapping File: '{0}'; Properties: {1}; Relationships: {2}",
                  Path.GetFileName(mappingFile),
                  parsedEntity.Properties.Count,
                  parsedEntity.Relationships.Count);

            return parsedEntity;
        }
    }
    #endregion

    #region Context Parser
    [DebuggerDisplay("Context: {ContextClass}")]
    public class ParsedContext
    {
        public ParsedContext()
        {
            Properties = new List<ParsedEntitySet>();
        }

        public string ContextClass { get; set; }

        public List<ParsedEntitySet> Properties { get; private set; }
    }

    [DebuggerDisplay("Entity: {EntityClass}, Property: {ContextProperty}")]
    public class ParsedEntitySet
    {
        public string EntityClass { get; set; }
        public string ContextProperty { get; set; }
    }

    public class ContextVisitor : CSharpSyntaxWalker
    {
        public ContextVisitor()
        {
            ContextBaseType = "DbContext";
            DataSetTypes = new HashSet<string> { "DbSet", "IDbSet" };
        }

        public string ContextBaseType { get; set; }

        public HashSet<string> DataSetTypes { get; set; }

        public ParsedContext ParsedContext { get; set; }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var hasBaseType = node.BaseList
                .DescendantNodes()
                .OfType<IdentifierNameSyntax>()
                .Any(i => i.Identifier.ValueText == ContextBaseType);

            if (hasBaseType)
            {
                var name = node.Identifier.Text;
                if (ParsedContext == null)
                    ParsedContext = new ParsedContext();

                ParsedContext.ContextClass = name;
            }

            base.VisitClassDeclaration(node);
        }

        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            ParseProperty(node);
            base.VisitPropertyDeclaration(node);
        }

        private void ParseProperty(PropertyDeclarationSyntax node)
        {
            var returnType = node.Type
                .DescendantNodesAndSelf()
                .OfType<GenericNameSyntax>()
                .FirstOrDefault();

            // expecting generic return type with 1 argument
            if (returnType == null || returnType.TypeArgumentList.Arguments.Count != 1)
                return;

            var returnName = returnType.Identifier.ValueText;
            if (!DataSetTypes.Contains(returnName))
                return;

            var firstArgument = returnType
                .TypeArgumentList
                .Arguments
                .FirstOrDefault();

            // last identifier is class name
            var className = firstArgument
                .DescendantNodesAndSelf()
                .OfType<IdentifierNameSyntax>()
                .Select(s => s.Identifier.ValueText)
                .LastOrDefault();

            var propertyName = node.Identifier.ValueText;

            if (string.IsNullOrEmpty(className) || string.IsNullOrEmpty(propertyName))
                return;

            var entitySet = new ParsedEntitySet
            {
                EntityClass = className,
                ContextProperty = propertyName
            };
            ParsedContext.Properties.Add(entitySet);
        }
    }

    public static class ContextParser
    {
        public static ParsedContext Parse(string contextFile)
        {
            if (string.IsNullOrEmpty(contextFile) || !File.Exists(contextFile))
                return null;

            var code = File.ReadAllText(contextFile);
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = (CompilationUnitSyntax)syntaxTree.GetRoot();

            var visitor = new ContextVisitor();
            visitor.Visit(root);

            var parsedContext = visitor.ParsedContext;

            if (parsedContext != null)
                Debug.WriteLine("Parsed Context File: '{0}'; Entities: {1}",
                  Path.GetFileName(contextFile),
                  parsedContext.Properties.Count);

            return parsedContext;
        }
    }
    #endregion

    public static class Synchronizer
    {
        public static bool UpdateFromSource(EntityContext generatedContext, string contextDirectory, string mappingDirectory)
        {
            if (generatedContext == null)
                return false;

            // make sure to update the entities before the context
            UpdateFromMapping(generatedContext, mappingDirectory);
            UpdateFromContext(generatedContext, contextDirectory);
            return true;
        }

        private static void UpdateFromContext(EntityContext generatedContext, string contextDirectory)
        {
            if (generatedContext == null
              || contextDirectory == null
              || !Directory.Exists(contextDirectory))
                return;

            // parse context
            ParsedContext parsedContext = null;
            using (var files = Directory.EnumerateFiles(contextDirectory, "*.Generated.cs").GetEnumerator())
            {
                while (files.MoveNext() && parsedContext == null)
                    parsedContext = ContextParser.Parse(files.Current);
            }

            if (parsedContext == null)
                return;

            if (generatedContext.ClassName != parsedContext.ContextClass)
            {
                Debug.WriteLine("Rename Context Class'{0}' to '{1}'.",
                                generatedContext.ClassName,
                                parsedContext.ContextClass);

                generatedContext.ClassName = parsedContext.ContextClass;
            }

            foreach (var parsedProperty in parsedContext.Properties)
            {
                var entity = generatedContext.Entities.ByClass(parsedProperty.EntityClass);
                if (entity == null)
                    continue;


                if (entity.ContextName == parsedProperty.ContextProperty)
                    continue;

                Debug.WriteLine("Rename Context Property'{0}' to '{1}'.",
                                entity.ContextName,
                                parsedProperty.ContextProperty);

                entity.ContextName = parsedProperty.ContextProperty;
            }
        }

        private static void UpdateFromMapping(EntityContext generatedContext, string mappingDirectory)
        {
            if (generatedContext == null
              || mappingDirectory == null
              || !Directory.Exists(mappingDirectory))
                return;

            // parse all mapping files
            var mappingFiles = Directory.EnumerateFiles(mappingDirectory, "*.Generated.cs");
            var parsedEntities = mappingFiles
              .Select(MappingParser.Parse)
              .Where(parsedEntity => parsedEntity != null)
              .ToList();

            var relationshipQueue = new List<Tuple<Entity, ParsedEntity>>();

            // update all entity and property names first because relationships are linked by property names
            foreach (var parsedEntity in parsedEntities)
            {
                // find entity by table name to support renaming entity
                var entity = generatedContext.Entities
                  .ByTable(parsedEntity.TableName, parsedEntity.TableSchema);

                if (entity == null)
                    continue;

                // sync names
                if (entity.MappingName != parsedEntity.MappingClass)
                {
                    Debug.WriteLine("Rename Mapping Class'{0}' to '{1}'.",
                          entity.MappingName,
                          parsedEntity.MappingClass);

                    entity.MappingName = parsedEntity.MappingClass;
                }

                // use rename api to make sure all instances are renamed
                generatedContext.RenameEntity(entity.ClassName, parsedEntity.EntityClass);

                // sync properties
                foreach (var parsedProperty in parsedEntity.Properties)
                {
                    // find property by column name to support property name rename
                    var property = entity.Properties.ByColumn(parsedProperty.ColumnName);
                    if (property == null)
                        continue;

                    // use rename api to make sure all instances are renamed
                    generatedContext.RenameProperty(
                      entity.ClassName,
                      property.PropertyName,
                      parsedProperty.PropertyName);
                }

                // save relationship for later processing
                var item = new Tuple<Entity, ParsedEntity>(entity, parsedEntity);
                relationshipQueue.Add(item);
            }

            // update relationships last
            foreach (var tuple in relationshipQueue)
                UpdateRelationships(generatedContext, tuple.Item1, tuple.Item2);
        }

        private static void UpdateRelationships(EntityContext generatedContext, Entity entity, ParsedEntity parsedEntity)
        {
            // sync relationships
            foreach (var parsedRelationship in parsedEntity.Relationships)
            {
                var parsedProperties = parsedRelationship.ThisProperties;
                var relationship = entity.Relationships
                    .FirstOrDefault(r => !r.ThisProperties.Except(parsedProperties).Any());

                if (relationship == null)
                    continue;

                bool isThisSame = relationship.ThisPropertyName == parsedRelationship.ThisPropertyName;
                bool isOtherSame = relationship.OtherPropertyName == parsedRelationship.OtherPropertyName;

                if (isThisSame && isOtherSame)
                    continue;

                if (!isThisSame)
                {
                    Debug.WriteLine("Rename Relationship Property '{0}.{1}' to '{0}.{2}'.",
                          relationship.ThisEntity,
                          relationship.ThisPropertyName,
                          parsedRelationship.ThisPropertyName);

                    relationship.ThisPropertyName = parsedRelationship.ThisPropertyName;
                }
                if (!isOtherSame)
                {
                    Debug.WriteLine("Rename Relationship Property '{0}.{1}' to '{0}.{2}'.",
                          relationship.OtherEntity,
                          relationship.OtherPropertyName,
                          parsedRelationship.OtherPropertyName);

                    relationship.OtherPropertyName = parsedRelationship.OtherPropertyName;
                }

                // sync other relationship
                var otherEntity = generatedContext.Entities.ByClass(relationship.OtherEntity);
                if (otherEntity == null)
                    continue;

                var otherRelationship = otherEntity.Relationships.ByName(relationship.RelationshipName);
                if (otherRelationship == null)
                    continue;

                otherRelationship.ThisPropertyName = relationship.OtherPropertyName;
                otherRelationship.OtherPropertyName = relationship.ThisPropertyName;
            }
        }
    }
}
