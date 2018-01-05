using Boolli.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Boolli.UnitTests
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

        [DataRow("and")]
        [DataRow("aNd")]
        [DataRow("or")]
        [DataRow("oR")]
        [DataRow("&&")]
        [DataRow("&")]
        [DataRow("||")]
        [DataRow("|")]
        [DataRow("!")]
        [DataRow("not")]
        [DataRow("noT")]
        [DataRow("true")]
        [DataRow("trUe")]
        [DataRow("false")]
        [DataRow("faLse")]
        [DataRow("0")]
        [DataRow("1")]
        [DataRow("^")]
        [DataRow("(")]
        [DataRow(")")]

        [ExpectedException(typeof(InvalidFunctionNameException))]
        [DataTestMethod]
        public void ExpressionConverter_Should_ThrowException_When_Using_Invalid_FunctionNames(string wrongFunctionName)
        {
            var expressionConverter = new FuncOfBoolExpressionsToBooleanExpressionConverter();
            var booleanExpression = expressionConverter.Convert(
                "f1 and f2 or f3",
                new NamedBooleanFunction[]
                {
                   new NamedBooleanFunction("f1", () => true),
                   new NamedBooleanFunction(wrongFunctionName, () => true),
                   new NamedBooleanFunction("f3", () => true),
                });
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

        [DataRow("and")]
        [DataRow("aNd")]
        [DataRow("or")]
        [DataRow("oR")]
        [DataRow("&&")]
        [DataRow("&")]
        [DataRow("||")]
        [DataRow("|")]
        [DataRow("!")]
        [DataRow("not")]
        [DataRow("noT")]
        [DataRow("true")]
        [DataRow("trUe")]
        [DataRow("false")]
        [DataRow("faLse")]
        [DataRow("0")]
        [DataRow("1")]
        [DataRow("^")]
        [DataRow("(")]
        [DataRow(")")]

        [ExpectedException(typeof(InvalidFunctionNameException))]
        [DataTestMethod]
        public async Task ExpressionConverter_Should_ThrowException_When_Using_Invalid_AsyncFunctionNames(string wrongFunctionName)
        {
            var expressionConverter = new FuncOfBoolExpressionsToBooleanExpressionConverter();
            var booleanExpression = await expressionConverter.Convert(
                "f1 and f2 or f3",
                new NamedAsyncBooleanFunction[]
                {
                   new NamedAsyncBooleanFunction("f1", async () => { await Task.Delay(100); return true; }),
                   new NamedAsyncBooleanFunction(wrongFunctionName, async () => { await Task.Delay(100); return true; }),
                   new NamedAsyncBooleanFunction("f3", async () => { await Task.Delay(100); return true; })
                });
        }

    }
}
