using System.Threading.Tasks;

namespace Boolli
{
    public class Evaluator
    {
        private readonly FuncOfBoolExpressionsToBooleanExpressionConverter _expressionConverter;
        private readonly AstInterpreter _astInterpreter;

        public Evaluator()
        {
            _expressionConverter = new FuncOfBoolExpressionsToBooleanExpressionConverter();
            _astInterpreter = new AstInterpreter();
        }

        public bool EvaluateBooleanExpression(string booleanExpression)
        {
            var lexer = new Lexer(booleanExpression);
            var parser = new AstParser(lexer);
            var parsedExpression = parser.Parse();
            var result = _astInterpreter.Interpret(parsedExpression);

            return result;
        }

        public bool EvaluateFuncOfBoolExpression(
            string funcOfBoolExpression, 
            params NamedBooleanFunction[] functions)
        {
            var booleanExpression = _expressionConverter.Convert(funcOfBoolExpression, functions);
            return EvaluateBooleanExpression(booleanExpression);
        }

        public async Task<bool> EvaluateFuncOfBoolExpressionAsync(
            string funcOfBoolExpression,
            params NamedAsyncBooleanFunction[] functions)
        {
            var booleanExpression = await _expressionConverter.Convert(funcOfBoolExpression, functions);
            return EvaluateBooleanExpression(booleanExpression);
        }
    }
}
