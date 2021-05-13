using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    //public InventoryData inv;
    //string []  inventory;
    List<GameObject> inventory = new List<GameObject>();
    RoomController roomWord;
    bool hasStarted = false;
    bool canMoveNextScene = false;
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
        GameObject tmpObj = null;
        //split[0].Contains("use") && split[1].Contains("")

            switch (inputSentence)
            {
                case "!inventory":
                    PrintInventory();
                    break;
                //case 
                case "!start":
                #region
                if (hasStarted == false)
                    {
                    //GameManager.Instance.LoadNextScene();
                    GameManager.Instance.FadeToLevel();
                    hasStarted = true;
                    }
                #endregion
                break;

                case "!quit":
                    GameManager.Instance.QuitGame();
                    break;

                case "!info":
                RoomController.Instance.UpdateRoomInitialDescription();
                    break;

            case "!forward":
                if(GameManager.Instance.CanMoveNextScene())
                {
                    //GameManager.Instance.LoadNextScene();
                    GameManager.Instance.FadeToLevel();
                }
                else
                {
                    Infotext.Instance.UpdateInfo("You can't move forward yet.");
                }
                break;

                default:
                Infotext.Instance.UpdateInfo("Improper command given!");
                    break;
                    
            }
        

        switch(split[0])
        {
            case "!use":
                #region
                if (split.Length > 1)
                {
                    if (CheckIfInventoryContainsItem(split[1]) != null)
                    {
                        if (split[1] == RoomController.Instance.ReturnCorrectItem().name )
                        {
                            Infotext.Instance.UpdateInfo($"You {split[0]} item {split[1]}. That was correct item. Good job! You can move forward now.");
                            DestroyItem(CheckIfInventoryContainsItem(split[1]));
                            
                            GameManager.Instance.ChangeCanMoveNextScene(true);
                            //GameManager.Instance.LoadNextScene();
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
                #endregion
                break;

            case "!look":
                #region
                if (split.Length > 1)
                {
                    //if (RoomController.Instance.ReturnLookObject(split[1]) != "")
                    if (CheckIfInventoryContainsItem(split[1]) != null )
                    {
                        tmpObj = CheckIfInventoryContainsItem(split[1]);
                        Infotext.Instance.UpdateInfo(tmpObj.GetComponent<Character>().ReturnDescription());
                    }
                    else if (CheckIfInventoryContainsItem(split[1]) == null && RoomController.Instance.ReturnRoomObject(split[1]) != null)
                    {
                        if (split[1] == RoomController.Instance.ReturnRoomObject(split[1]).name)
                        {
                            tmpObj = RoomController.Instance.ReturnRoomObject(split[1]);
                            //Infotext.Instance.UpdateInfo($"You {split[0]} item {split[1]}. It looks like you can take it.");
                            Infotext.Instance.UpdateInfo($" {tmpObj.GetComponent<Character>().ReturnDescription()}");
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

                #endregion
                break;

            case "!take":
                #region
                if (split.Length > 1)
                {
                    if (RoomController.Instance.ReturnRoomObject(split[1]) != null)
                    {
                        if (split[1] == RoomController.Instance.ReturnRoomObject(split[1]).name)
                        {
                            tmpObj = RoomController.Instance.ReturnRoomObject(split[1]);

                            if(tmpObj.GetComponent<Character>().CanYouTakeItem()== true)
                            {
                               if( CheckIfInventoryContainsItem(split[1]) == null)
                                {
                                    //inventory.Add(RoomController.Instance.ReturnRoomObject(split[1]));
                                    AddItemToInventory(RoomController.Instance.ReturnRoomObject(split[1]));
                                    Infotext.Instance.UpdateInfo($"You take {split[1]}.");
                                    //PrintInventory();
                                }
                               else
                                {
                                    Infotext.Instance.UpdateInfo($"You already have a {split[1]}.");
                                }
                                
                            }
                            else
                            {
                                Infotext.Instance.UpdateInfo($"You can't take {split[1]}.");
                            }
                        }
                        else
                        {
                            Infotext.Instance.UpdateInfo($"I can't find a {split[1]}.");
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
                #endregion
                break;
            case "!talk":
                #region
                if (split.Length > 1)
                {
                    if (split[1] == RoomController.Instance.ReturnRoomObject(split[1]).name)
                    {
                        tmpObj = RoomController.Instance.ReturnRoomObject(split[1]);
                        Infotext.Instance.UpdateInfo($" {tmpObj.GetComponent<Character>().ReturnDialogue()}");
                        //Infotext.Instance.UpdateInfo(RoomController.Instance.GetDialogue(split[1]));
                    }     
                }

                else
                {
                    Infotext.Instance.UpdateInfo($"There is no one to talk.");
                }
                    break;
            #endregion    
        }

    }

    public GameObject CheckIfInventoryContainsItem(string item)
    {
        GameObject tmp = null;
        if (inventory.Any())
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].name == item)
                {
                    //Infotext.Instance.UpdateInfo($"Löytyi tavara {item}");
                    tmp = inventory[i];
                    
                }
            }
        }

        return tmp;
    }

    public void PrintInventory()
    {
        Infotext.Instance.EmptyInventory();
        for (int i = 0; i < inventory.Count;)
        {
            Infotext.Instance.UpdateInventory($"{inventory[i].name}");
            i++;
        }
    }


    public void AddItemToInventory(GameObject obj)
    {
        GameObject newObj = Instantiate(obj, transform.position, Quaternion.identity);

        newObj.GetComponent<Character>().UpdateParent();
        newObj.name = obj.name;
        inventory.Add(newObj);
        PrintInventory();
        
    }

    public void DestroyItem(GameObject obj)
    {
        obj.GetComponent<Character>().DestroySelf();
        inventory.Remove(CheckIfInventoryContainsItem(obj.name));
        PrintInventory();
    }

}
