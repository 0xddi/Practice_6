namespace Practice6;

class Program
{
    static void Main()
    {
        try
        {
            var inputPathToDirectory = Input.SpawnInputPathOfDirectory();

            var dictionaryOfDirectoryFiles = Parser.ParseDirectory(inputPathToDirectory);
      
            var pathOfChosenFile = Input.SpawnInputChooseFileFromDirectory(dictionaryOfDirectoryFiles);

            var fileExtension = FileExtensionMethods.GetFileExtension(pathOfChosenFile);
            
            var numberOfLinesToSkip = Input.SpawnInputNumberOfLinesToSkip();
            
            var numberOfLinesToPrint = Input.SpawnInputNumberOfLinesToPrint();

            var allColumns = Parser.GetNamesForColumns(pathOfChosenFile, fileExtension);
            
            Output.PrintColumnNames(allColumns, false);

            var chosenColumns = Input.SpawnInputChosenColumns(allColumns);

            Parser.GetAndPrintLinesFromFile(pathOfChosenFile, fileExtension, numberOfLinesToPrint, chosenColumns, numberOfLinesToSkip);
        }
        
        catch (Exception ex)
        {
            Console.WriteLine("[!] The program has ran into some problem. The error message will be displayed below:");
            Console.WriteLine(ex.Message);
        }

    }
}