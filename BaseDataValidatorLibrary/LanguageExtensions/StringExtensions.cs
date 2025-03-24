using System.Text.RegularExpressions;
#pragma warning disable SYSLIB1045

namespace BaseDataValidatorLibrary.LanguageExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Splits a camel-cased string into separate words by inserting spaces before each uppercase letter.
        /// </summary>
        /// <param name="sender">The camel-cased string to process.</param>
        /// <returns>A string with spaces inserted before each uppercase letter, preserving the original word order.</returns>
        public static string SplitCamelCase(this string sender) =>
            string.Join(" ", CamelCasePattern().Matches(sender)
                .Select(m => m.Value));

        [GeneratedRegex(@"([A-Z][a-z]+)")]
        private static partial Regex CamelCasePattern();

        private static readonly Regex Reg = new("([a-z,0-9](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", RegexOptions.Compiled);

        /// <summary>
        /// This splits up a string based on capital letters
        /// e.g. "MyAction" would become "My Action" and "My10Action" would become "My10 Action"
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string SplitPascalCase(this string sender) 
            => Reg.Replace(sender, "$1 ");
    }
}
