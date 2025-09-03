using System.Collections.Generic;
using UnityEngine;

public class ItemTable : DataTable
{
    public class Data
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }

    }

    public Data itemData = new Data();
    private readonly Dictionary<string, Data> dictionary = new Dictionary<string, Data>();


    public override void Load(string filename)
    {
        dictionary.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);

        var list = LoadCSV<Data>(textAsset.text);

        foreach (var item in list)
        {
            if (!dictionary.ContainsKey(item.Id))
            {
                dictionary.Add(item.Id, itemData);
            }
            else
            {
                Debug.LogError($"Å° Áßº¹: {item.Id}");
            }
        }
    }
}
