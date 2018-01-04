using Boolli;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Bolli.UnitTests
{
    [TestClass]
    public class FuncOfBoolExpressionsToBooleanExpressionConverterTestCase
    {
        [TestMethod]
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

        [TestMethod]
        public async Task ExpressionConverter_Should_Correctly_Convert_AsyncFunc_Expressions()
        {
            var expressionConverter = new FuncOfBoolExpressionsToBooleanExpressionConverter();
            var booleanExpression = await expressionConverter.Convert(
                "f1 and f2 or f3",
                new NamedAsyncBooleanFunction[]
                {
                   new NamedAsyncBooleanFunction("f1", async () => { await Task.Delay(100); return true; }),
                   new NamedAsyncBooleanFunction("f2", async () => { await Task.Delay(100); return true; }),
                   new NamedAsyncBooleanFunction("f3", async () => { await Task.Delay(100); return true; })
                });

            Assert.IsTrue(booleanExpression == "true and true or true");
        }
    }
}
