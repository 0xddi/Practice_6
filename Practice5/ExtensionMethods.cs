namespace Practice5;

public static class ExtensionMethods
{
    public static char GetSeparatorChar(this FileExtension fileExtension)
    {
        if (fileExtension == FileExtension.Csv) return ';';
        if (fileExtension == FileExtension.Tsv) return '\t';
        throw new Exception("Unsupported file extension");
    }
}