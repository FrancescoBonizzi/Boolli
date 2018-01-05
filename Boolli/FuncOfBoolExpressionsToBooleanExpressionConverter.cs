using Boolli.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boolli
{
    public class FuncOfBoolExpressionsToBooleanExpressionConverter
    {
        public string Convert(
            string funcOfBoolExpression,
            IEnumerable<NamedBooleanFunction> functions)
        {
            // TODO Spacca se non ci sono tutte le f nell'expression
            // TODO Check che non vengano utilizzati come nomi di funzioni delle parole chiave del linguaggio

            string booleanExpression = funcOfBoolExpression;
            foreach (var func in functions)
                booleanExpression = booleanExpression.Replace(func.Name, func.Function().ToBoolliString());

            return booleanExpression;
        }

        public async Task<string> Convert(
            string funcOfBoolExpression,
            IEnumerable<NamedAsyncBooleanFunction> asyncFunctions)
        {
            // TODO Spacca se non ci sono tutte, o se ci sono booleanFunction con lo stesso nome
            // TODO Check che non vengano utilizzati come nomi di funzioni delle parole chiave del linguaggio

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
