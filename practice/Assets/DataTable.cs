using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using System.Linq;

public abstract class DataTable
{
    public static readonly string FormatPath = "DataTables/{0}";

    public abstract void Load(string filename);

    public static List<T> LoadCSV<T>(string csvTest)
    {
        using (var reader = new StringReader(csvTest))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<T>();
            return records.ToList();
        }
    }
}