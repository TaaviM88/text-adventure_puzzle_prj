using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchLib.Api.Models.Undocumented.Chatters;
using TwitchLib.Api.Models.Undocumented.ChatUser;
using System.Threading.Tasks;
using TwitchLib.Unity;

public class TwitchApi : MonoBehaviour
{
    public static TwitchApi Instance;
    public Api api;

    public GameObject client;
    TwitchClient clientScript;
    // Start is called before the first frame update
    void Start()
    {
        api = new Api();
        api.Settings.AccessToken = Secret.bot_access_token;
        api.Settings.ClientId = Secret.client_id;
        clientScript = client.GetComponent<TwitchClient>();
        if (clientScript == null)
        {
            Debug.Log("Didn't find a client script");
        }
        Debug.Log("Found client script");
    }

    private void GetChatterListCallBack(List<ChatterFormatted> obj)
    {
        Debug.Log("list of " + obj.Count + " Viewers: ");
        foreach (var chatter in obj)
        {
            Debug.Log(chatter.Username);
        }
    }
    public async System.Threading.Tasks.Task GetUserIDAsync(string id, string username)
    {
        api.Invoke(api.Undocumented.GetChatUserAsync(id, username), GetChatUserAsync);
        await api.Users.v5.GetUserByIDAsync(id);
        Debug.Log(api.Users.helix.GetUsersFollowsAsync());
    }

    private void GetChatUserAsync(ChatUserResponse obj)
    {
        // obj.DisplayName
        Debug.Log(obj);
    }
}
