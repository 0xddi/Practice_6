namespace Practice6;

public enum FileExtension
{
    Csv,
    Tsv
}


public static class FileExtensionMethods
{
    public static FileExtension GetFileExtension(string filePath)
    {
        string fileExtension = Path.GetExtension(filePath);
        switch (fileExtension)
        {
            case ".csv": return FileExtension.Csv;
            case ".tsv": return FileExtension.Tsv;
            default: 
                throw new Exception($"Unknown file extension of the file {filePath}");
        }
    }
}