using System;

namespace Boolli
{
    public class Evaluator
    {
        public bool EvaluateBooleanExpression(string booleanExpression)
        {
            var interpreter = new AstInterpreter();
            var lexer = new Lexer(booleanExpression);
            var parser = new AstParser(lexer);
            var parsedExpression = parser.Parse();
            var result = interpreter.Interpret(parsedExpression);

            return result;
        }

        public bool EvaluateFuncOfBoolExpression(
            string funcOfBoolExpression, 
            params NamedBooleanFunction[] functions)
        {
            var interpreter = new AstInterpreter();
            var expressionConverter = new FuncOfBoolExpressionsToBooleanExpressionConverter();

            var booleanExpression = expressionConverter.Convert(funcOfBoolExpression, functions);
           
            var lexer = new Lexer(booleanExpression);
            var parser = new AstParser(lexer);
            var parsedExpression = parser.Parse();
            var result = interpreter.Interpret(parsedExpression);

            return result;
        }
    }
}
