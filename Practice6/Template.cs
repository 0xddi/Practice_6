namespace Practice6;

public static class Template
{
    public static string[] GetTemplateForColumns(string columns, FileExtension fileExt)
    {
        char separator = fileExt.GetSeparatorChar();
        var templateColumns =  columns.Split(separator);
        return templateColumns;
    }
}