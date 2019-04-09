using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomController : MonoBehaviour
{
    public static RoomController Instance;
    [SerializeField]
    private GameObject correctItem;

    [SerializeField]
    private List <GameObject> roomObjects = new List<GameObject>();

    [SerializeField]
    private string initialDescription = "Puuttuu teksti.";

    float currentTimer = 0;
    float time = 30f;
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Destroy" + gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        GameManager.Instance.UpdateCorrectWord(correctItem);
        UpdateRoomInitialDescription();
        GameManager.Instance.ChangeCanMoveNextScene(false);
    }

//timer if you want to initial description come to automatic
    /* private void Update()
     {
         if (!Infotext.Instance.ReturnCurrentInfoText().Equals(initialDescription))
         {
             if (currentTimer > 0)
             {
                 currentTimer -= Time.deltaTime;
                 Debug.Log($"Timer {currentTimer}. Huoneen alustus teksti {initialDescription}. Infoboksissa oleva teksti: {Infotext.Instance.ReturnCurrentInfoText()}");
             }
             else
             {
                 currentTimer = time;
                 UpdateRoomInitialDescription();
             }
         }
    }*/

    public GameObject ReturnCorrectItem()
    {
        return correctItem;
    }

    public void UpdateRoomInitialDescription()
    {
        Infotext.Instance.UpdateInfo(initialDescription);
    }

    public GameObject ReturnRoomObject(string name)
    {
        GameObject tmp = null;

        for (int i = 0; i< roomObjects.Count; i++)
        {
            if(roomObjects[i].name == name)
            {
                tmp = roomObjects[i];
            }
        }

        return tmp;
    }

    public void AddObjectToList(GameObject obj)
    {
        roomObjects.Add(obj);
    }

    public void EmptyList()
    {
        roomObjects.Clear();
    }
}
