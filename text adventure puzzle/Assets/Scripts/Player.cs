using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Player : MonoBehaviour
{
    public InventoryData inv;
    RoomController roomWord;
    bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        PrintInventory();
    }


    public void GetSentence(string inputSentence)
    {
        string[] split = inputSentence.Split(' ');
        //split[0].Contains("use") && split[1].Contains("")
        if(split[0].Contains("use"))
        {
            if(CheckIfInventoryContainsItem(split[1]) != "")
            {
                if (split[1] == GameManager.Instance.ReturnCorrectWord())
                {
                    Infotext.Instance.UpdateInfo($"You {split[0]} item {split[1]}. That was correct item. Good job!");
                    GameManager.Instance.LoadNextScene();
                }
            }
            else
            {
                Infotext.Instance.UpdateInfo($"You {split[0]} item {split[1]}. It didn't do anything.");
            }
        }

        else
        {
            switch (inputSentence)
            {
                case "inventory":
                    PrintInventory();
                    break;
                //case 
                case "start":
                    if (hasStarted == false)
                    {
                        GameManager.Instance.LoadNextScene();
                        hasStarted = true;
                    }
                    
                    break;
                default:
                    Infotext.Instance.UpdateInfo("Improper command given!");
                    break;
            }
        }
        
            
        /*
        if (inputSentence.Contains("inventory"))
        {
            PrintInventory();
        }

        if(inputSentence.Contains("a"))
        {
            Infotext.Instance.UpdateInfo($"{inv.itemName.Length}");
        }
        
        if()*/
    }

    public string CheckIfInventoryContainsItem(string item)
    {
        string tmp = "";
        for (int i = 0; i < inv.itemName.Length;)
        {
            if (inv.itemName[i] == item)
            {

                Infotext.Instance.UpdateInfo($"Löytyi tavara {item}");
                tmp = item;
                break;
            }
            else if (inv.itemName[i] == inv.itemName.Last() && inv.itemName[i] != item)
            {
                Infotext.Instance.UpdateInfo($"Ei löydy {item} esinettä.Kirjoita uusi");
                tmp = "";
            }        
                i++;
        }

        if (tmp != "")
        {
            return item;
        }
        else
            return tmp;

    }

    public void PrintInventory()
    {
        for (int i = 0; i < inv.itemName.Length;)
        {
            Infotext.Instance.UpdateInventory($"{inv.itemName[i]}");
            i++;
        }
    }

}
