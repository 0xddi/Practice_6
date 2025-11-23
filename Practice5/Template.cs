namespace Practice5;

public static class Template
{
    public static string[] GetTemplateForProperties(string columns, FileExtension fileExt)
    {
        char separator = fileExt.GetSeparatorChar();
        var templateColumns =  columns.Split(separator);
        return templateColumns;
    }
}