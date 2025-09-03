using UnityEngine;
using TMPro;

public class StringTableText : MonoBehaviour
{
    public string id;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro.text = DataTableManager.StringTable.Get(id);
    }
}
