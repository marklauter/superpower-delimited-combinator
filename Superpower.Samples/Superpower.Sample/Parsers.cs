using Superpower;
using Superpower.Display;
using Superpower.Model;
using Superpower.Parsers;
using Superpower.Tokenizers;
using System.Diagnostics.CodeAnalysis;

internal enum DelimtedTextToken
{
    [Token(Category = "delimiter", Example = ";")]
    Semicolon,

    Value,

    NullValue,
}

internal static class TextParsers
{
    public static TextParser<string> NullValue { get; } =
        from start in Character.EqualTo(';')
        from ignore in Character.WhiteSpace.Many()
        from close in Character.EqualTo(';')
        select "empty";
}

internal static class Tokenizer
{
    public static Tokenizer<DelimtedTextToken> Instance { get; } =
        new TokenizerBuilder<DelimtedTextToken>()
            .Ignore(Span.WhiteSpace)
            .Match(TextParsers.NullValue, DelimtedTextToken.NullValue)
            .Match(Character.EqualTo(';'), DelimtedTextToken.Semicolon)
            .Match(Character.Except(';').Many(), DelimtedTextToken.Value)
            .Build();
}

internal static class DelimitedListParser
{
    public static bool TryParse(
        string input,
        out TokenList<DelimtedTextToken>? value,
        [MaybeNullWhen(true)] out string error,
        out Position errorPosition)
    {
        var tokens = Tokenizer.Instance.TryTokenize(input);
        if (!tokens.HasValue)
        {
            value = null;
            error = tokens.ToString();
            errorPosition = Position.Empty;
            return false;
        }

        value = tokens.Value;
        error = null;
        errorPosition = Position.Empty;
        return true;
    }
}