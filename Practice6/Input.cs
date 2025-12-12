namespace Practice6;

public class Input
{
    public static string SpawnInputPathOfDirectory()
    {
        Console.Write("Enter a path to a directory: ");
        var inputPathToDirectory = Console.ReadLine()!.Trim('"');
        if (!Input.ValidatePathToDirectory(inputPathToDirectory)) throw new Exception("Invalid path");
        return inputPathToDirectory; 
    }

    public static string SpawnInputChooseFileFromDirectory(Dictionary<int, string> dictionaryOfDirectoryFiles)
    {
        Output.PrintDictionaryOfFilesFromDirectory(dictionaryOfDirectoryFiles);
        Console.Write("Enter the number of file to be parsed: ");
        var chosenNumberOfFileAsKey = int.Parse(Console.ReadLine()!);
        if (!ValidateChosenNumberOfFile(chosenNumberOfFileAsKey, dictionaryOfDirectoryFiles))
            throw new Exception("Invalid number of file");
        var pathOfChosenFile = dictionaryOfDirectoryFiles[chosenNumberOfFileAsKey];
        return pathOfChosenFile;
    }

    public static int SpawnInputNumberOfLinesToSkip()
    {
        Console.Write("Enter the number of lines to be skipped: ");
        var tempStoreForSkip = Console.ReadLine();
        if (!Input.ValidateNumberOfLines(tempStoreForSkip!)) throw new Exception("Invalid number of lines to skip");
        var numberOfLinesToSkip = int.Parse(tempStoreForSkip!);
        return numberOfLinesToSkip;
    }

    public static int SpawnInputNumberOfLinesToPrint()
    {
        Console.Write("Enter the number of lines to print: ");
        var tempStoreForLinesToPrint = Console.ReadLine();
        if (!Input.ValidateNumberOfLines(tempStoreForLinesToPrint!))
            throw new Exception("Invalid number of lines to skip");
        var numberOfLinesToPrint = int.Parse(tempStoreForLinesToPrint!);
        Console.WriteLine("The chosen file have been successfully found. Column names of it will be displayed on the next line"); // Это должно быть не тут, но да ладно
        return numberOfLinesToPrint;
    }

    public static string[] SpawnInputChosenColumns(string[] allColumns)
    {
        Console.Write("Now enter the names of columns to be displayed divided by ',' (order also matters): ");
        var tempStoreForChosenColumns = Console.ReadLine()!.Replace(" ", ""); // getting rid of space whitespaces. To remove all whitespaces it is needed to use either Regex.Replace or some LINQ tricks
        string[] chosenColumns;
        if (tempStoreForChosenColumns == "*")
        {
            chosenColumns = allColumns;
        }
        else
        {
            if (!Input.ValidateChosenColumns(tempStoreForChosenColumns, allColumns))
                throw new Exception("Invalid names of columns");
            chosenColumns = tempStoreForChosenColumns.Split(',');
        }
        return chosenColumns;
    }
    
    public static bool ValidatePathToDirectory(string pathToDirectory)
    {
        return Directory.Exists(pathToDirectory);
    }

    public static bool ValidateNumberOfLines(string inputNumberOfLines)
    {
        bool isInteger = int.TryParse(inputNumberOfLines, out _);
        return isInteger;
    }

    public static bool ValidateChosenColumns(string chosenColumns, string[] origProperties)
    {
        var dissected = chosenColumns.Split(',');
        bool validStatus = true;
        foreach (var property in dissected)
        {
            if (!origProperties.Contains(property)) validStatus = false;
        }
        return validStatus;
    }

    public static bool ValidateChosenNumberOfFile(int number, Dictionary<int, string> fileDictionary)
    {
        if (!fileDictionary.ContainsKey(number)) return false;
        return true;
    }
    
}