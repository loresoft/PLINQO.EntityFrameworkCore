using System;
using Xunit;

namespace SchemaMapper.Tests
{

    public class ExtensionsTest
    {

        [Fact]
        public void IsCSharpKeywordTest()
        {
            bool actual;

            actual = "Public".IsKeyword(CodeLanguage.CSharp);
            Assert.False(actual);

            actual = "case".IsKeyword(CodeLanguage.CSharp);
            Assert.True(actual);

            actual = "public".IsKeyword(CodeLanguage.CSharp);
            Assert.True(actual);

            actual = "void".IsKeyword(CodeLanguage.CSharp);
            Assert.True(actual);

            actual = "do".IsKeyword(CodeLanguage.CSharp);
            Assert.True(actual);
        }

        [Fact]
        public void IsVisualBasicKeywordTest()
        {
            bool actual;

            actual = "Public".IsKeyword(CodeLanguage.VisualBasic);
            Assert.True(actual);

            actual = "case".IsKeyword(CodeLanguage.VisualBasic);
            Assert.True(actual);

            actual = "public".IsKeyword(CodeLanguage.VisualBasic);
            Assert.True(actual);

            actual = "do".IsKeyword(CodeLanguage.VisualBasic);
            Assert.True(actual);
        }

        [Fact]
        public void ToNullableTypeTest()
        {
            var int64Type = typeof(Int64);
            var dateTimeType = typeof(DateTime);
            var stringType = typeof(string);

            string actual = int64Type.ToNullableType(true);
            Assert.Equal("long?", actual);

            actual = int64Type.ToNullableType(false);
            Assert.Equal("long", actual);

            actual = dateTimeType.ToNullableType(true);
            Assert.Equal("System.DateTime?", actual);

            actual = dateTimeType.ToNullableType(false);
            Assert.Equal("System.DateTime", actual);

            actual = stringType.ToNullableType(true);
            Assert.Equal("string", actual);

            actual = stringType.ToNullableType(false);
            Assert.Equal("string", actual);

        }

        [Fact]
        public void UniqueNamerTest()
        {
            var namer = new UniqueNamer();

            string result;

            result = namer.UniqueName("Tester", "Users");
            Assert.Equal("Users", result);

            result = namer.UniqueName("Tester", "Users");
            Assert.Equal("Users1", result);

            result = namer.UniqueName("Tester", "Users");
            Assert.Equal("Users2", result);

        }
    }
}
