using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class ModelFileTyped
{
    private readonly GldfFileTyped _gldfFileTyped;

    public string FileName
    {
        get => _gldfFileTyped.FileName;
        set => _gldfFileTyped.FileName = value;
    }

    public string Uri
    {
        get => _gldfFileTyped.Uri;
        set => _gldfFileTyped.Uri = value;
    }

    public FileContentType ContentType
    {
        get => _gldfFileTyped.ContentType;
        set => _gldfFileTyped.ContentType = value;
    }

    public FileType Type
    {
        get => _gldfFileTyped.Type;
        set => _gldfFileTyped.Type = value;
    }

    public string Language
    {
        get => _gldfFileTyped.Language;
        set => _gldfFileTyped.Language = value;
    }

    public byte[] BinaryContent
    {
        get => _gldfFileTyped.BinaryContent;
        set => _gldfFileTyped.BinaryContent = value;
    }
        
    public LevelOfDetail? LevelOfDetail { get; set; }
        
    public ModelFileTyped()
    {
        _gldfFileTyped = new GldfFileTyped();
    }
        
    public ModelFileTyped(GldfFileTyped gldfFileTyped, LevelOfDetail? levelOfDetail = null)
    {
        _gldfFileTyped = gldfFileTyped;
        LevelOfDetail = levelOfDetail;
    }
}