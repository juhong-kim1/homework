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

    private readonly Dictionary<string, Data> dictionary = new Dictionary<string, Data>();


    public override void Load(string filename)
    {
        throw new System.NotImplementedException();
    }
}
