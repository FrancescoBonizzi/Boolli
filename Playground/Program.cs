using Boolli;
using System;
using System.Diagnostics;

namespace Playground
{

    class Program
    {
        static void Main(string[] args)
        {
            string input = null;

            do
            {
                try
                {
                    Console.Write("> ");
                    input = Console.ReadLine();
                    var boolli = new Evaluator();
                    Console.WriteLine(boolli.EvaluateBooleanExpression(input));
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!string.IsNullOrEmpty(input));

            Console.Read();
        }
    }
}
