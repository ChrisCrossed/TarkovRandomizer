using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.IO;

public class c_MainMenu : MonoBehaviour
{
    Button QuitButton;

    GameObject go_MainData;
    c_ProgramData MainData;

    InputField inputField_TwitchChannel;

    Text uiText_TextPreface;
    InputField inputField_ChatPreface;

    Text uiText_TextRegisterUser;
    InputField inputField_ChatRegisterUser;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetMOTD());
        StartCoroutine(CheckVersion());

        QuitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        QuitButton.onClick.AddListener(delegate { Quit(); });

        go_MainData = GameObject.Find("MainData");
        MainData = go_MainData.GetComponent<c_ProgramData>();

        inputField_TwitchChannel = GameObject.Find("inputfield_ChannelName").gameObject.GetComponent<InputField>();
        inputField_TwitchChannel.onValueChanged.AddListener(delegate { TwitchChannelName(inputField_TwitchChannel); });

        uiText_TextRegisterUser = GameObject.Find("Text_TextRegisterUser").gameObject.GetComponent<Text>();
        inputField_ChatRegisterUser = GameObject.Find("inputfield_ChatRegisterUser").gameObject.GetComponent<InputField>();
        inputField_ChatRegisterUser.onValueChanged.AddListener(delegate { TwitchTextRegisterUser(inputField_ChatRegisterUser); });
        inputField_ChatRegisterUser.OnDeselect(new BaseEventData(EventSystem.current));

        // Text Preface goes last to ensure other fields exist and can be updated in realtime
        uiText_TextPreface = GameObject.Find("Text_TextPreface").gameObject.GetComponent<Text>();
        inputField_ChatPreface = GameObject.Find("inputfield_ChatPreface").gameObject.GetComponent<InputField>();
        inputField_ChatPreface.onValueChanged.AddListener(delegate { TwitchTextChatPreface(inputField_ChatPreface); });
        inputField_ChatPreface.onValueChanged.AddListener(delegate { TwitchTextRegisterUser(inputField_ChatRegisterUser); });
        inputField_ChatPreface.OnDeselect(new BaseEventData(EventSystem.current));

        // If file exists on hard drive, preload data. Otherwise, force presets
        MainData.ChatPreface = DEFAULT_CHAT_PREFACE;
        MainData.ChatCommand_RegisterUser = DEFAULT_CHAT_REGISTER_USER;
    }

    void TwitchChannelName( InputField _change )
    {
        if(MainData)
        {
            MainData.TwitchChannel = _change.text;

            MainData.TwitchChannel = MainData.TwitchChannel.Replace(" ", string.Empty);
            MainData.TwitchChannel = MainData.TwitchChannel.ToLower();

            inputField_TwitchChannel.text = MainData.TwitchChannel;
        }
        else throw new System.NotImplementedException("MainData Not Found - Not Implemented");
    }

    const string DEFAULT_CHAT_PREFACE = "tr";
    void TwitchTextChatPreface( InputField _change )
    {
        if(MainData)
        {
            ChatPrefaceDeselected = false;

            SetChatPreface( _change.text );
        }
        else throw new System.NotImplementedException("MainData Not Found - Not Implemented");
    }

    void SetChatPreface( string _change )
    {
        MainData.ChatPreface = _change;
        MainData.ChatPreface = MainData.ChatPreface.Replace(" ", string.Empty);
        MainData.ChatPreface = MainData.ChatPreface.ToLower();
        uiText_TextPreface.text = "Twitch Command Preface : !" + MainData.ChatPreface;

        if (MainData.ChatPreface == DEFAULT_CHAT_PREFACE) uiText_TextPreface.text += " (Default)";

        inputField_ChatPreface.text = MainData.ChatPreface;
    }

    const string DEFAULT_CHAT_REGISTER_USER = "register";
    void TwitchTextRegisterUser( InputField _change )
    {
        if (MainData)
        {
            ChatRegisterUserDeselected = false;

            SetRegisterUserText(_change.text);
        }
        else throw new System.NotImplementedException("MainData Not Found - Not Implemented");
    }

    void SetRegisterUserText( string _change )
    {
        MainData.ChatCommand_RegisterUser = _change;
        MainData.ChatCommand_RegisterUser = MainData.ChatCommand_RegisterUser.Replace(" ", string.Empty);
        MainData.ChatCommand_RegisterUser = MainData.ChatCommand_RegisterUser.ToLower();
        uiText_TextRegisterUser.text = "User Self Registration : !" + MainData.ChatPreface + " " + MainData.ChatCommand_RegisterUser;

        if (MainData.ChatCommand_RegisterUser == DEFAULT_CHAT_REGISTER_USER) uiText_TextRegisterUser.text += " (Default)";

        inputField_ChatRegisterUser.text = MainData.ChatCommand_RegisterUser;
    }

    IEnumerator SetMOTD()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get("https://de21b71f-1c75-44c1-acb2-0bc5624c68bf.usrfiles.com/ugd/de21b7_67b6d859b8dc4753923117a6321cf890.txt");

        var asyncOperation = webRequest.SendWebRequest();

        while (!asyncOperation.isDone) yield return null;

        while (!webRequest.isDone) yield return null;

        string motd = webRequest.downloadHandler.text;

        print(motd);

        yield return null;
    }

    IEnumerator CheckVersion()
    {
        // Get version on file
        string path = "Assets/Version/version.txt";
        StreamReader reader = new StreamReader(path);
        string output = reader.ReadLine();
        float version = float.Parse(output);
        print(version);
        reader.Close();

        yield return null;
    }

    bool ChatPrefaceDeselected = true;
    bool ChatRegisterUserDeselected = true;
    // Update is called once per frame
    void Update()
    {
        if(!inputField_ChatPreface.isFocused && !ChatPrefaceDeselected)
        {
            ChatPrefaceDeselected = true;

            if (MainData.ChatPreface.Length == 0)
            {
                SetChatPreface(DEFAULT_CHAT_PREFACE);
                inputField_ChatPreface.text = DEFAULT_CHAT_PREFACE;
            }
        }

        if(!inputField_ChatRegisterUser.isFocused && !ChatRegisterUserDeselected)
        {
            ChatRegisterUserDeselected = true;

            if(MainData.ChatCommand_RegisterUser.Length == 0)
            {
                SetRegisterUserText(DEFAULT_CHAT_REGISTER_USER);
                inputField_ChatRegisterUser.text = DEFAULT_CHAT_REGISTER_USER;
            }
        }
    }

    private void Quit()
    {
        Application.Quit();
    }
}
