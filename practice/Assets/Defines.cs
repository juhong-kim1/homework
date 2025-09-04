using UnityEngine;

public enum Languages
{
    Korean,
    English,
    Japan,
}

public static class DataTableIds
{

    public static readonly string[] StringTableIds =
    {
        "stringTableKr",
        "stringTableEn",
        "stringTableJp",

    };

    public static readonly string Item = "itemNameTable";

    public static string String => StringTableIds[(int)Variables.Language]; 
}

public static class Variables
{
    public static Languages Language = Languages.Korean;


}
