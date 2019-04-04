using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Player : MonoBehaviour
{
    //public InventoryData inv;
    //string []  inventory;
    List<string> inventory = new List<string>();
    RoomController roomWord;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        if(inventory.Any())
        {
            PrintInventory();
        }
    }


    public void GetSentence(string inputSentence)
    {
        string[] split = inputSentence.Split(' ');
        //split[0].Contains("use") && split[1].Contains("")
       
        if(split[0].Contains("use"))
        {
            if (split.Length > 1)
            {

                if (CheckIfInventoryContainsItem(split[1]) != "")
                {
                    if (split[1] == GameManager.Instance.ReturnCorrectWord())
                    {
                        Infotext.Instance.UpdateInfo($"You {split[0]} item {split[1]}. That was correct item. Good job!");
                        inventory.Remove(split[1]);
                        PrintInventory();
                        GameManager.Instance.LoadNextScene();
                    }
                    else
                    {
                        Infotext.Instance.UpdateInfo($"You {split[0]} item {split[1]}. It didn't do anything.");
                    }
                }

                else
                {
                    Infotext.Instance.UpdateInfo($"You you dont have  {split[1]}.");
                }
            }
            else
            {
                Infotext.Instance.UpdateInfo($"{split[0]} what?");
            }
        }

        else if(split[0].Contains("look"))
        {
            if (split.Length > 1)
            {
                if (RoomController.Instance.ReturnLookObject(split[1]) != "")
                {
                    if (split[1] == RoomController.Instance.ReturnLookObject(split[1]))
                    {
                        Infotext.Instance.UpdateInfo($"You {split[0]} item {split[1]}. It looks like you can take it.");
                    }
                    else
                    {
                        Infotext.Instance.UpdateInfo($"There is nothing intresting");
                    }
                }
            }
            else
            {
                Infotext.Instance.UpdateInfo($"{split[0]} what?");
            }
        }

        else if(split[0].Contains("take"))
        {
            if (split.Length > 1)
            {
                if (split[1] != CheckIfInventoryContainsItem(split[1]))
                {
                    if (split[1] == RoomController.Instance.ReturnLookObject(split[1]))
                    {
                        inventory.Add(split[1]);
                        Infotext.Instance.UpdateInfo($"You take {split[1]}.");
                        PrintInventory();
                    }
                    else
                    {
                        Infotext.Instance.UpdateInfo($"You can't take {split[1]}.");
                    }
                }
                else
                {
                    Infotext.Instance.UpdateInfo($"You already have {split[1]}.");
                }
            }
            else
            {
                Infotext.Instance.UpdateInfo($"{split[0]} what?");
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

                case "quit":
                    GameManager.Instance.QuitGame();
                    break;
                default:
                    Infotext.Instance.UpdateInfo("Improper command given!");
                    break;
            }
        }

    }

    public string CheckIfInventoryContainsItem(string item)
    {
        string tmp = "";
        if (inventory.Any())
        {

            for (int i = 0; i < inventory.Count;)
            {
                if (inventory[i] == item)
                {

                    //Infotext.Instance.UpdateInfo($"Löytyi tavara {item}");
                    tmp = item;
                    break;
                }
                else if (inventory[i] == inventory.Last() && inventory[i] != item)
                {
                    //Infotext.Instance.UpdateInfo($"Ei löydy {item} esinettä.Kirjoita uusi");
                    tmp = "";
                }
                i++;
            }
        }
        else
        {
            Debug.Log(inventory.Count);
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
        Infotext.Instance.EmptyInventory();
        for (int i = 0; i < inventory.Count;)
        {
            Infotext.Instance.UpdateInventory($"{inventory[i]}");
            i++;
        }
    }


    public void AddItemToInventory(string obj)
    {
        inventory.Add(obj);
    }
}
