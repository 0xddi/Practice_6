namespace Practice5;

public enum FileExtension
{
    Csv,
    Tsv
}


public static class TemporaryName
{
    public static FileExtension GetFileExtension(string filePath)
    {
        string fileExtension = Path.GetExtension(filePath);
        if (fileExtension == ".csv")
            return FileExtension.Csv;
        else if (fileExtension == ".tsv")
            return FileExtension.Tsv;
        else 
            throw new Exception($"Unknown file extension of the file {filePath}");
    }
}