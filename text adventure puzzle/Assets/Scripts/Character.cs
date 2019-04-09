using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    [SerializeField]
    private string description;

    [SerializeField]
    private string dialogue;

    [SerializeField]
    private bool canTake = true;

    private void Start()
    {
        
        RoomController.Instance.AddObjectToList(gameObject);
    }


    public string ReturnDescription()
    {
        return description;
    }

    public string ReturnDialogue()
    {
        return dialogue;
    }

    public bool CanYouTakeItem()
    {
        return canTake;
    }

    public void UpdateParent()
    {
        gameObject.transform.SetParent(FindObjectOfType<Player>().transform);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
