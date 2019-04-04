using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomController : MonoBehaviour
{
    public static RoomController Instance;
    [SerializeField]
    private string correctItem;

    [SerializeField]
    private string[] lookItems;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        GameManager.Instance.UpdateCorrectWord(correctItem);
        Infotext.Instance.EmptyInfo();
        
    }

    public string ReturnCorrectItem()
    {
        return correctItem;
    }

    public string ReturnLookObject(string obj)
    {
        string tmp = "";
        if (0 < lookItems.Length)
        {
            for (int i = 0; i < lookItems.Length;)
            {
                if (lookItems[i] == obj)
                {

                    Infotext.Instance.UpdateInfo($"You looked {obj}");
                    tmp = obj;
                    break;
                }
                else if (lookItems[i] == lookItems.Last() && lookItems[i] != obj)
                {
                    Infotext.Instance.UpdateInfo($"There is nothing intresting.");
                    tmp = "";
                }
                i++;
            }
        }
        return tmp;
    }

    public string TakeItem(string obj)
    {
        string tmp = "";

        if (0 < lookItems.Length)
        {
            for (int i = 0; i < lookItems.Length;)
            {
                if (lookItems[i] == obj)
                {

                    Infotext.Instance.UpdateInfo($"You looked {obj}");
                    tmp = obj;
                    break;
                }
                else if (lookItems[i] == lookItems.Last() && lookItems[i] != obj)
                {
                    Infotext.Instance.UpdateInfo($"There is nothing intresting.");
                    tmp = "";
                }
                i++;
            }
        }
        return tmp;
    }
}
