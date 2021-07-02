using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchLib.Unity;

public static class Secrets
{
    public const string CLIENT_ID = "8oup6o62zu4f6em0hyz14liymgwjsw"; //Your application's client ID, register one at https://dev.twitch.tv/dashboard
    public const string OAUTH_TOKEN = "epeijpuyp32yb8ysl9nj6vlae2ymaq"; //A Twitch OAuth token which can be used to connect to the chat
    public const string USERNAME_FROM_OAUTH_TOKEN = "ChrisChrisBot"; //The username which was used to generate the OAuth token
    public const string CHANNEL_ID_FROM_OAUTH_TOKEN = "702736505"; //The channel Id from the account which was used to generate the OAuth token
    public const string REFRESH_TOKEN = "1qc622ou3yxqv1v8o5g8z298oq0m5uesagsg8x67dconpaf5lr"; //https://twitchtokengenerator.com/
}

public class c_TwitchConnect : MonoBehaviour
{
    private PubSub _pubSub;

    // Start is called before the first frame update
    void Start()
    {
        // Create new instance of PubSub Client
        _pubSub = new PubSub();

        // Subscribe to events
        _pubSub.OnWhisper += OnWhisper;
        _pubSub.OnPubSubServiceConnected += OnPubSubServiceConnected;

        _pubSub.Connect();
    }

    private void _pubSub_OnWhisper(object sender, TwitchLib.PubSub.Events.OnWhisperArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void OnPubSubServiceConnected(object sender, System.EventArgs e)
    {
        Debug.Log("PubSubServiceConnected!");

        // On Connect listen to Bits events
        // Please note that listening to the whisper events requires the chat_login scope in the OAuth token
        _pubSub.ListenToBitsEventsV2(Secrets.CHANNEL_ID_FROM_OAUTH_TOKEN); // ChrisChrisDev_TarkovRandomizer

        _pubSub.SendTopics(Secrets.OAUTH_TOKEN);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnWhisper(object sender, TwitchLib.PubSub.Events.OnWhisperArgs e)
    {
        Debug.Log($"{e.Whisper.Data}");
        // Do your bits logic here
    }
}
