using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

public class CsvData
{
    public string Id { get; set; }
    public string String { get; set; }


}

public class CSVTest1 : MonoBehaviour
{
    void Start()
    {
        TextAsset csv = Resources.Load<TextAsset>("DataTables/stringTableKr");

        using (var reader = new StringReader(csv.text))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<CsvData>();

            foreach (var record in records)
            {
                Debug.Log($"{record.Id} : {record.String}");
            }
        }
    }
}
