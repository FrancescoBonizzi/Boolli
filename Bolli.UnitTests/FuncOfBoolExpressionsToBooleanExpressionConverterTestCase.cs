using Boolli;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bolli.UnitTests
{
    [TestClass]
    public class FuncOfBoolExpressionsToBooleanExpressionConverterTestCase
    {
        [DataTestMethod]
        public void ExpressionConverter_Should_Correctly_Convert_Expressions()
        {
            var expressionConverter = new FuncOfBoolExpressionsToBooleanExpressionConverter();
            var booleanExpression = expressionConverter.Convert(
                "f1 and f2 or f3",
                new NamedBooleanFunction[]
                {
                   new NamedBooleanFunction("f1", () => true),
                   new NamedBooleanFunction("f2", () => true),
                   new NamedBooleanFunction("f3", () => true),
                });

            Assert.IsTrue(booleanExpression == "true and true or true");
        }
    }
}
