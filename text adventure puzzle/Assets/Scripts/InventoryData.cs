using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "scriptable objects/Create Inventory")]
public class InventoryData : ScriptableObject
{
    public string[] itemName;
}
