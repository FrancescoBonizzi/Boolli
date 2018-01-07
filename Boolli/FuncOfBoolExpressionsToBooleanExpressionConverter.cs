using Boolli.Exceptions;
using Boolli.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boolli
{
    internal class FuncOfBoolExpressionsToBooleanExpressionConverter
    {
        private readonly string[] _languageKeywords;

        public FuncOfBoolExpressionsToBooleanExpressionConverter()
        {
            _languageKeywords = Domain.LanguageKeywords;
        }

        private void ValidateFunctionsNames(IEnumerable<string> functionsNames)
        {
            foreach(var functionName in functionsNames)
            {
                foreach(var languageKeyword in _languageKeywords)
                {
                    if (string.Compare(functionName, languageKeyword, true) == 0)
                        throw new InvalidFunctionNameException(functionName, _languageKeywords);
                }
            }
        }

        public string Convert(
            string funcOfBoolExpression,
            IEnumerable<NamedBooleanFunction> functions)
        {
            ValidateFunctionsNames(functions.Select(f => f.Name));
            string booleanExpression = funcOfBoolExpression;

            foreach (var func in functions)
            {
                var thisFunctResult = func.Function();
                booleanExpression = booleanExpression.Replace(func.Name, thisFunctResult.ToBoolliString());
            }

            return booleanExpression;
        }

        public async Task<string> Convert(
            string funcOfBoolExpression,
            IEnumerable<NamedAsyncBooleanFunction> asyncFunctions)
        {
            ValidateFunctionsNames(asyncFunctions.Select(f => f.Name));
            string booleanExpression = funcOfBoolExpression;

            foreach (var func in asyncFunctions)
            {
                var thisFuncResult = await func.AsyncFunction();
                booleanExpression = booleanExpression.Replace(func.Name, thisFuncResult.ToBoolliString());
            }

            return booleanExpression;
        }

    }
}
