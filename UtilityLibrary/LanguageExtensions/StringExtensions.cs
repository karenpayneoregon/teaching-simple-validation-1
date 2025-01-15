using System.Text.RegularExpressions;

namespace UtilityLibrary.LanguageExtensions;

/// <summary>
/// Common string extensions 
/// </summary>
public static partial class StringExtensions
{

    /// <summary>
    /// Use to split on upper-cased characters and separate with a single space.
    /// </summary>
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", UpperCaseSplitterRegex().Matches(sender)
            .Select(m => m.Value));

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex UpperCaseSplitterRegex();
}