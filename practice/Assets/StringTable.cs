using UnityEngine;
using System.Collections.Generic;

public class StringTable : DataTable
{
    public static readonly string Unknown = "Unknown Key";

    public class Data
    {
        public string Id { get; set; }
        public string String { get; set; }
    }

    private readonly Dictionary<string,string> dictionary = new Dictionary<string,string>();

    public override void Load(string filename)
    {
        dictionary.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);

        Debug.Log(path);

        var list = LoadCSV<Data>(textAsset.text);

        foreach (var item in list)
        {
            if (!dictionary.ContainsKey(item.Id))
            {
                dictionary.Add(item.Id, item.String);
            }
            else
            {
                Debug.LogError($"Å° Áßº¹: {item.Id}");
            }
        }
    }

    public string Get(string key)
    {
        if (!dictionary.ContainsKey(key))
        {
            return Unknown;
        }
        return dictionary[key];
    }
}
