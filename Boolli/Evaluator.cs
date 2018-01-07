using System.Threading.Tasks;

namespace Boolli
{
    /// <summary>
    /// Exposes some methods to evaluate boolean expressions
    /// </summary>
    public class Evaluator
    {
        private readonly FuncOfBoolExpressionsToBooleanExpressionConverter _expressionConverter;
        private readonly AstInterpreter _astInterpreter;

        /// <summary>
        /// Constructs a boolean expression evaluator
        /// </summary>
        public Evaluator()
        {
            _expressionConverter = new FuncOfBoolExpressionsToBooleanExpressionConverter();
            _astInterpreter = new AstInterpreter();
        }

        /// <summary>
        /// It returns true or false given a boolean expression"
        /// </summary>
        /// <param name="booleanExpression">A boolean expression such as "true and false or (true and false)</param>
        /// <returns></returns>
        public bool EvaluateBooleanExpression(string booleanExpression)
        {
            var lexer = new Lexer(booleanExpression);
            var parser = new AstParser(lexer);
            var parsedExpression = parser.Parse();
            var result = _astInterpreter.Interpret(parsedExpression);

            return result;
        }

        /// <summary>
        /// It return true or false given a boolean expression composed of boolean functions
        /// </summary>
        /// <param name="funcOfBoolExpression">A boolean expression such as "f1 and f2 or (f3 and f4)</param>
        /// <param name="functions">A collection of <see cref="NamedBooleanFunction"/> that exposes some boolean functions with a name associated</param>
        /// <returns></returns>
        public bool EvaluateFuncOfBoolExpression(
            string funcOfBoolExpression, 
            params NamedBooleanFunction[] functions)
        {
            var booleanExpression = _expressionConverter.Convert(funcOfBoolExpression, functions);
            return EvaluateBooleanExpression(booleanExpression);
        }

        /// <summary>
        /// It return true or false given a boolean expression composed of async boolean functions
        /// </summary>
        /// <param name="funcOfBoolExpression">A boolean expression such as "f1 and f2 or (f3 and f4)</param>
        /// <param name="functions">A collection of <see cref="NamedAsyncBooleanFunction"/> that exposes some async boolean functions with a name associated</param>
        /// <returns></returns>
        public async Task<bool> EvaluateFuncOfBoolExpressionAsync(
            string funcOfBoolExpression,
            params NamedAsyncBooleanFunction[] functions)
        {
            var booleanExpression = await _expressionConverter.Convert(funcOfBoolExpression, functions);
            return EvaluateBooleanExpression(booleanExpression);
        }
    }
}
