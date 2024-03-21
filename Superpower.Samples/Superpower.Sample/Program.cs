var inputs = new string[]
{
    "TEST123;TEST456;;HALLO",
    "TEST123;TEST456; ;HALLO",
    "TEST123;TEST456;  ;HALLO",
};

for (var i = 0; i < inputs.Length; ++i)
{
    var input = inputs[i];

    var parsed = DelimitedListParser.TryParse(
        input,
        out var value,
        out var error,
        out var errorPosition);

    var output = parsed && value.HasValue
        ? String.Join(Environment.NewLine, value.Value)
        : $"err: {error}, pos: {errorPosition}";

    Console.WriteLine($"INPUT: {input}");
    Console.WriteLine("OUTPUT:");
    Console.WriteLine(output);
    Console.WriteLine();
    Console.WriteLine();
}

