namespace Practice5;

public static class Output
{
    public static void PrintParsedLines(List<IDictionary<string, object>> parsedLines, string[] desiredColumnsInOrder)
    {
        foreach (var columnName in desiredColumnsInOrder)
        {
            Console.Write(columnName + "\t");
        }
        Console.WriteLine();
        
        foreach (var line in parsedLines)
        {
            foreach (var column in desiredColumnsInOrder)
            {
                Console.Write(line[column] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static void PrintDictionaryOfFilesFromDirectory(Dictionary<int, string> filesDictionary) 
    {
        foreach (KeyValuePair<int, string> file in filesDictionary)
        {
            Console.WriteLine(file.Key + ". " + Path.GetFileName(file.Value));
        }
    }

    public static void PrintPropertyNames(string[] propertyNames)
    {
        foreach (string propertyName in propertyNames)
        {
            Console.Write(propertyName + " | ");
        }
        Console.WriteLine();
    }
    
}