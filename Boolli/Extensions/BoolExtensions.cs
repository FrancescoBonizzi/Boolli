namespace Boolli.Extensions
{
    public static class BoolExtensions
    {
        public static string ToBoolliString(this bool value)
            => value ? "true" : "false"; // Per definire formalmente il mapping
    }
}
