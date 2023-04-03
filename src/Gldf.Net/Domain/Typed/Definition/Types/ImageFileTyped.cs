using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class ImageFileTyped
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

    public ImageType ImageType { get; set; }

    public ImageFileTyped()
    {
        _gldfFileTyped = new GldfFileTyped();
        ImageType = ImageType.Other;
    }
        
    public ImageFileTyped(GldfFileTyped gldfFileTyped, ImageType imageType)
    {
        _gldfFileTyped = gldfFileTyped;
        ImageType = imageType;
    }
}