using UnityEngine;
using System.Collections.Generic;

public static class DataTableManager
{
    private static readonly Dictionary<string, DataTable> tables =
        new Dictionary<string, DataTable>();

    static DataTableManager()
    {
        Init();
    }

    private static void Init()
    {
#if UNITY_EDITOR
        foreach (var id in DataTableIds.StringTableIds)
        {
            var table = new StringTable();
            table.Load(id);
            tables.Add(id, table);
        }
#else
        var stringTable = new StringTable();
        stringTable.Load(DataTableIds.String);
        tables.Add(DataTableIds.String, stringTable);

#endif
    }

    public static StringTable StringTable
    {
        get 
        {
            return Get<StringTable>(DataTableIds.String);
        } 
      
    }


    public static T Get<T>(string id) where T: DataTable
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError("���̺����");
            return null;
        }
        return tables[id] as T;
    }
}
