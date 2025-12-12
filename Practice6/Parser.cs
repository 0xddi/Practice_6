using System.Dynamic;

namespace Practice6;

public static class Parser
{
    public static void GetAndPrintLinesFromFile(string filePath, FileExtension fileExt,  int numberOfLinesToPrint, string[] neededColumns, int numberOfLinesToSkip = 0)
    {
        char separatorChar = fileExt.GetSeparatorChar();
        
        
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                string[]? templateForColumns = null;
                int lineCounter = 0;
                while ((line = sr.ReadLine()!) is not null && lineCounter < numberOfLinesToPrint + numberOfLinesToSkip + 1)
                {
                    if (lineCounter == 0)
                    {
                        templateForColumns = Template.GetTemplateForColumns(line, fileExt);
                        Output.PrintColumnNames(neededColumns, true);
                        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 33 * neededColumns.Length - 1)));
                        lineCounter++;
                        continue;
                    }

                    if (lineCounter > numberOfLinesToSkip)
                    {
                        var lineDividedByColumns = new LineWithColumns(line, templateForColumns!, neededColumns, separatorChar);
                        Console.WriteLine(lineDividedByColumns);
                    }
                    lineCounter++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ". Couldn't read the file at some point.");
        }
    }

    public static string[] GetNamesForColumns(string pathToFile, FileExtension fileExt)
    {
        char separatorChar = fileExt.GetSeparatorChar();
        using (StreamReader sr = new StreamReader(pathToFile))
        {
            return sr.ReadLine()!.Split(separatorChar);
        }
    }

    public static Dictionary<int, string> ParseDirectory(string pathToDirectory)
    {
        string[] allFiles = Directory.GetFiles(pathToDirectory);
        var fileDictionary = new Dictionary<int, string>();

        int numberOfFile = 1;
        foreach (var file in allFiles)
        {
            fileDictionary.Add(numberOfFile, file);
            numberOfFile++;
        }
        return fileDictionary;
    }
    
    
}