namespace Practice6;

public static class ExtensionMethods
{
    public static char GetSeparatorChar(this FileExtension fileExtension)
    {
        switch (fileExtension)
        {
            case FileExtension.Csv: return ';';
            case FileExtension.Tsv: return '\t';
            default: throw new Exception($"Unsupported file extension: {fileExtension}");
        }
    }
}