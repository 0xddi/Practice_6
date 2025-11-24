namespace Practice6;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter a path to a directory: ");
            var inputPathToDirectory = Console.ReadLine().Trim('"');
            if (!Input.ValidatePathToDirectory(inputPathToDirectory)) throw new Exception("Invalid path");

            var dictionaryOfDirectoryFiles = Parser.ParseDirectory(inputPathToDirectory);
            Output.PrintDictionaryOfFilesFromDirectory(dictionaryOfDirectoryFiles);
            Console.Write("Enter the number of file to be parsed: ");
            var chosenNumberOfFileAsKey = int.Parse(Console.ReadLine());
            if (!Input.ValidateChosenNumberOfFile(chosenNumberOfFileAsKey, dictionaryOfDirectoryFiles))
                throw new Exception("Invalid number of file");
            var pathOfChosenFile = dictionaryOfDirectoryFiles[chosenNumberOfFileAsKey];

            var fileExtension = FileExtensionMethods.GetFileExtension(pathOfChosenFile);

            Console.Write("Enter the number of lines to be skipped: ");
            var tempStoreForSkip = Console.ReadLine();
            if (!Input.ValidateNumberOfLines(tempStoreForSkip)) throw new Exception("Invalid number of lines to skip");
            var numberOfLinesToSkip = int.Parse(tempStoreForSkip);

            Console.Write("Enter the number of lines to print: ");
            var tempStoreForLinesToPrint = Console.ReadLine();
            if (!Input.ValidateNumberOfLines(tempStoreForLinesToPrint))
                throw new Exception("Invalid number of lines to skip");
            var numberOfLinesToPrint = int.Parse(tempStoreForLinesToPrint);

            var readLines = Parser.GetLinesFromFile(pathOfChosenFile, out var propertyNames, fileExtension,
                numberOfLinesToPrint, numberOfLinesToSkip);
            Console.WriteLine("The chosen file have been successfully parsed. Column names of it will be displayed on the next line"); // even doe it's not true
            Output.PrintPropertyNames(propertyNames);
            Console.Write("Now enter the names of columns to be displayed divided by ',' (order also matters): ");
            var tempColumnsToDisplay = Console.ReadLine().Replace(" ", ""); // getting rid of space whitespaces. To remove all whitespaces it is needed to use either Regex.Replace or some LINQ tricks
            string[] inputPropertyNames;
            if (tempColumnsToDisplay == "*")
            {
                inputPropertyNames = propertyNames;
            }
            else
            {
                if (!Input.ValidateChosenColumns(tempColumnsToDisplay, propertyNames))
                    throw new Exception("Invalid names of columns");
                inputPropertyNames = tempColumnsToDisplay.Split(',');
            }


            var parsedLines = Parser.ParseLines(readLines, fileExtension, propertyNames);

            Output.PrintParsedLines(parsedLines, inputPropertyNames);

        }
        catch (Exception ex)
        {
            Console.WriteLine("The program has ran into some problem. The error message will be displayed below:");
            Console.WriteLine(ex.Message);
        }

    }
}