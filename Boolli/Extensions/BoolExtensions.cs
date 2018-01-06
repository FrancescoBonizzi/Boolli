namespace Boolli.Extensions
{
    internal static class BoolExtensions
    {
        /// <summary>
        /// Formally defines .NET bool string representation for this library
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBoolliString(this bool value)
            => value ? "true" : "false";
    }
}
