using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Weapon,
    Equip,
    Consumable,
}

public class ItemData
{
    public string Id { get; set; }
    public ItemTypes Type { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public int Value { get; set; }
    public int Cost { get; set; }
    public string Icon { get; set; }

    public override string ToString()
    {
        return $"{Id}/{Type}<{Name}/{Desc}/{Value}/{Cost}/{Icon}";
    }

    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringDesc => DataTableManager.StringTable.Get(Desc);

    public Sprite spriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");
}



public class ItemTable : DataTable
{
    private readonly Dictionary<string, ItemData> table = new Dictionary<string, Data>();


    public override void Load(string filename)
    {
        table.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);

        var list = LoadCSV<ItemData>(textAsset.text);

        foreach (var item in list)
        {
            if (!table.ContainsKey(item.Id))
            {
                table.Add(item.Id, item);
            }
            else
            {
                Debug.LogError($"아이템 아이디 중복: {item.Id}");
            }
        }

        foreach (var item in table)
        {
            Debug.Log(item.Value);
        }
    }

    public ItemData Get(string id)
    {
        if (!table.ContainsKey(id))
        {
            Debug.Log($"아이템을 찾을 수 없습니다: {id}");
            return null;
        }

        return table[id];
    }
}
