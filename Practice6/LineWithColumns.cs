namespace Practice6;

public class LineWithColumns
{
    Dictionary<string, string> Columns { get; }

    public LineWithColumns(string lineFromFile, string[] templateForColumns, string[] neededColumns, char separatorChar)
    {
        var dissectedLine = lineFromFile.Split(separatorChar);
        if (dissectedLine.Length != templateForColumns.Length)
        {
            throw new ArgumentException("The number of lines does not match the number of template columns.");
        }
        
        List<int> indexes = new List<int>();
        foreach (var neededColumn in neededColumns)
        {
            indexes.Add(Array.IndexOf(templateForColumns, neededColumn));
        }
        
        this.Columns = new Dictionary<string, string>();
        foreach (var index in indexes)
        {
            this.Columns.Add(templateForColumns[index], dissectedLine[index]);
        }

        
    }

    public override string ToString()
    {
        string storeForString = "";
        foreach (KeyValuePair<string, string> column in this.Columns)
        {
            storeForString += column.Value.PadRight(30) + " | ";
        }
        return storeForString;
    }
}