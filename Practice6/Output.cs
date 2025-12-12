namespace Practice6;

public static class Output
{
    public static void PrintDictionaryOfFilesFromDirectory(Dictionary<int, string> filesDictionary) 
    {
        foreach (KeyValuePair<int, string> file in filesDictionary)
        {
            Console.WriteLine(file.Key + ". " + Path.GetFileName(file.Value));
        }
    }

    public static void PrintColumnNames(string[] templateForColumns, bool isPaddingNeeded)
    {
        foreach (string columnName in templateForColumns)
        {
            if (isPaddingNeeded)
            {
                Console.Write(columnName.PadRight(30) + " | ");
            }
            else
            {
                Console.Write(columnName + " | ");
            }
        }
        Console.WriteLine();
    }
    
}