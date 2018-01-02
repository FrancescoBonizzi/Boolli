using Boolli.Extensions;
using System.Collections.Generic;

namespace Boolli
{
    public class FuncOfBoolExpressionsToBooleanExpressionConverter
    {
        public string Convert(
            string funcOfBoolExpression,
            IEnumerable<NamedBooleanFunction> functions)
        {
            // TODO Spacca se non ci sono tutte, o se ci sono booleanFunction con lo stesso nome
            
            string booleanExpression = funcOfBoolExpression;
            foreach (var func in functions)
                booleanExpression = booleanExpression.Replace(func.Name, func.Function().ToBoolliString());

            return booleanExpression;
        }

    }
}
