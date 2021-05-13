using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchLib.Client.Models;
using TwitchLib.Unity;
using System;
using TwitchLib.Client.Events;
using TMPro;
using UnityEngine.UI;
using TTS;



public class TwitchClient : MonoBehaviour
{
    public Client client { get; set; }
    [SerializeField]
    private string channel_name = "mutti88";
    bool hasConnected = false;
    ConnectionCredentials credentials;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        credentials = new ConnectionCredentials("kuuttijr", Secret.bot_access_token);
        client = new Client();
        client.Initialize(credentials, channel_name);

        client.OnConnected += OnConnected;
        client.OnMessageReceived += MyMessageReceivedFunction;
        client.OnChatCommandReceived += OnChatCommandReceived;
        client.Connect();

        player = GetComponent<Player>();
    }

    private void OnConnected(object sender, OnConnectedArgs e)
    {

        Debug.Log($"The bot {e.BotUsername} succesfully connected to Twitch.");
        //ChatLog.Instance.InfoText($"The bot {e.BotUsername} succesfully connected to Twitch.");
        hasConnected = true;

        if (!string.IsNullOrWhiteSpace(e.AutoJoinChannel))
            //ChatLog.Instance.InfoText($"The bot will now attempt to automatically join the channel provided when the Initialize method was called: {e.AutoJoinChannel}");
            Debug.Log($"The bot will now attempt to automatically join the channel provided when the Initialize method was called: {e.AutoJoinChannel}");
    }

    private void OnJoinedChannel(object sender, TwitchLib.Client.Events.OnJoinedChannelArgs e)
    {
        Debug.Log($"The bot {e.BotUsername} just joined the channel: {e.Channel}");
        //ChatLog.Instance.InfoText(e.Channel + " I just joined the channel! PogChamp");

    }

    private void OnChatCommandReceived(object sender, TwitchLib.Client.Events.OnChatCommandReceivedArgs e)
    {
        //Debug.Log(e.Command.ArgumentsAsString);
        //player.GetSentence(e.Command.ArgumentsAsString);
        /* switch (e.Command.CommandText)
         {
             case "raffle":
                 if (!subsOnly)
                 {
                     //RaffleList.Instance.AddName(e.Command.ChatMessage.DisplayName);

                     Debug.Log("lisätty raffleen");
                 }
                 else
                 {
                     if (e.Command.ChatMessage.IsSubscriber)
                     {
                         //RaffleList.Instance.AddName(e.Command.ChatMessage.DisplayName);

                         Debug.Log("lisätty subi raffleen");
                     }
                 }
                 break;

                 case "benis":
                      client.SendMessage(client.JoinedChannels[0], "Benis");
                      break;
                  case "help":
                      client.SendMessage(client.JoinedChannels[0], "Not for you babe.");
                      break;
         }*/

    }

    public void JoinChannel()
    {
        client.JoinChannel(channel_name);
        /*ChatLog.Instance.EmptyLog();
        RaffleList.Instance.EmpyNameList();
        RaffleList.Instance.GetAllNames();*/
    }


    private void MyMessageReceivedFunction(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
    {
        string message = e.ChatMessage.Message;
        player.GetSentence(e.ChatMessage.Message);
        TTSTest.Instance.GetMessage($"User {e.ChatMessage.DisplayName} says {e.ChatMessage.Message}");
        /*   if (RaffleList.Instance.GetWinnerName() == null)
           {
               ChatLog.Instance.Log(e.ChatMessage.DisplayName + ": " + message);
           }
           else if (e.ChatMessage.DisplayName.ToString() == RaffleList.Instance.GetWinnerName())
           {
               ChatLog.Instance.Log(e.ChatMessage.DisplayName + ": " + message);
           }*/

        //Debug.Log("The bot just read a message in chat");
    }

    public void LeaveChannel()
    {
        client.LeaveChannel(channel_name);
    }
}
    

