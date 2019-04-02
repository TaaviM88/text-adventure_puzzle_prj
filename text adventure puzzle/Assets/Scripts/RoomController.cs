using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField]
    private string correctItem;

    private void Start()
    {
        GameManager.Instance.UpdateCorrectWord(correctItem);
    }

    public string ReturnCorrectItem()
    {
        return correctItem;
    }
}
