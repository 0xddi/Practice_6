using System.Dynamic;

namespace Practice6;

public static class Parser
{
    public static List<string> GetLinesFromFile(string filePath, out string[] propertyNames, FileExtension fileExt,  int numberOfLinesToPrint, int numberOfLinesToSkip = 0)
    {
        List<string> lines = new();
        propertyNames = null; // some value needs to be assigned before exiting method
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int lineCounter = 0;
                while ((line = sr.ReadLine()) is not null && lineCounter < numberOfLinesToPrint + numberOfLinesToSkip + 1)
                {
                    if (lineCounter == 0)
                    {
                        propertyNames = Template.GetTemplateForProperties(line, fileExt);
                        lineCounter++;
                        continue;
                    }

                    if (lineCounter > numberOfLinesToSkip)
                    {
                        lines.Add(line);
                    }
                    
                    lineCounter++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ". Couldn't read the file at some point.");
        }
        
        if (!lines.Any()) throw new Exception("The file has ended before skipping/printing the supposed amount of lines");
        
        return lines;
    }
    
    
    
    public static List<IDictionary<string, object>> ParseLines(List<string> lines, FileExtension fileExt, string[] propertyNames)
    {
        int lengthOfPropertyNames = propertyNames.Length;
        List<IDictionary<string, object>> parsedLines = new();
        
        foreach (string line in lines)
        {
            var propertyValues = line.Split(fileExt.GetSeparatorChar());
            dynamic expando = new ExpandoObject();
            var lineDictionary = new Dictionary<string, object>();
            for (int i = 0; i < lengthOfPropertyNames; i++)
            {
                lineDictionary.Add(propertyNames[i], propertyValues[i]);
            }
            parsedLines.Add(lineDictionary);
        }
        return parsedLines;
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