namespace Gldf.Net.Domain.Typed.Head.Types;

public class FormatVersionTyped
{
    public int Major { get; set; }

    public int Minor { get; set; }

    public int? PreRelease { get; set; }

    public override string ToString() => $"v{Major}.{Minor}" + (PreRelease != null ? $"-rc{PreRelease}" : string.Empty);
}