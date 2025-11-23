namespace Practice5;

public class Input
{
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