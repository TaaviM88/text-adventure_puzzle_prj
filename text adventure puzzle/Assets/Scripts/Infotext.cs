using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Infotext : MonoBehaviour
{
    [SerializeField]
    TMP_Text infotext;
    [SerializeField]
    TMP_Text inventorytext;
    public static Infotext Instance;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;

    }

    public void UpdateInfo(string text)
    {
        infotext.text = $" {text} ";
    }

    public void EmptyInfo()
    {
        infotext.text = "";
    }

    public void UpdateInventory(string text)
    {
        inventorytext.text += $"{text} \n";
    }
}
