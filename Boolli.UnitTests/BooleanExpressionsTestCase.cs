using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Boolli.UnitTests
{
    [TestClass]
    public class BooleanExpressionsTestCase
    {
        // Casi base
        [DataRow("true", true)]
        [DataRow("false", false)]
        [DataRow("not true", false)]
        [DataRow("not false", true)]

        // N-abilità del not
        [DataRow("not not false", false)]
        [DataRow("not not true", true)]

        // Precedenza del not
        [DataRow("true and not false", true)]
        [DataRow("true and not true", false)]

        // and
        [DataRow("true and false", false)]
        [DataRow("false and true", false)]
        [DataRow("false and false", false)]
        [DataRow("true and true", true)]

        // or
        [DataRow("true or false", true)]
        [DataRow("false or true", true)]
        [DataRow("true or true", true)]
        [DataRow("false or false", false)]

        // Associatività a sinistra
        [DataRow("false and false or true", true)] // Associando a sinistra fa true, a destra fa false
        [DataRow("false and true or true", true)] // Associando a sinistra fa true, a destra fa false

        // Parentesi
        [DataRow("(true)", true)]
        [DataRow("(true) and (false)", false)]
        [DataRow("(true) and not (false)", true)]
        [DataRow("true and (true)", true)]
        [DataRow("true and (true and true)", true)]
        [DataRow("true and (true and false)", false)]
        [DataRow("(true and false) and (true and false)", false)]
        [DataRow("(true and false) or (true and false)", false)]

        // Sostitutibilità dei token
        [DataRow("True", true)]
        [DataRow("TRUE", true)]
        [DataRow("TrUe", true)]
        [DataRow("1", true)]
        [DataRow("1 and 0", false)]
        [DataRow("1 and false", false)]
        [DataRow("0 or false", false)]
        [DataRow("false or 1", true)]
        [DataRow("False", false)]
        [DataRow("FALSE", false)]
        [DataRow("FaLsE", false)]
        [DataRow("0", false)]
        [DataRow("True AND false", false)]
        [DataRow("True && false", false)]
        [DataRow("True AnD false", false)]
        [DataRow("True Or false", true)]
        [DataRow("True || false", true)]
        [DataRow("True OR false", true)]
        [DataRow("NoT True", false)]
        [DataRow("! True", false)]

        [DataTestMethod]
        public void Boolli_Should_Evaluate_Correctly_Good_Expressions(
            string expression, bool result)
        {
            var boolli = new Evaluator();
            Assert.IsTrue(boolli.EvaluateBooleanExpression(expression) == result);
        }
    }
}
