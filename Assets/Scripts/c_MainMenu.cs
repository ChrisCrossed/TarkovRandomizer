using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class c_MainMenu : MonoBehaviour
{
    GameObject go_MainData;
    c_ProgramData MainData;

    InputField inputField_TwitchChannel;

    Text uiText_TextPreface;
    InputField inputField_ChatPreface;

    // Start is called before the first frame update
    void Start()
    {
        go_MainData = GameObject.Find("MainData");
        MainData = go_MainData.GetComponent<c_ProgramData>();

        inputField_TwitchChannel = GameObject.Find("inputfield_ChannelName").gameObject.GetComponent<InputField>();
        inputField_TwitchChannel.onValueChanged.AddListener(delegate { TwitchChannelName(inputField_TwitchChannel); });

        uiText_TextPreface = GameObject.Find("Text_TextPreface").gameObject.GetComponent<Text>();
        inputField_ChatPreface = GameObject.Find("inputfield_ChatPreface").gameObject.GetComponent<InputField>();
        inputField_ChatPreface.onValueChanged.AddListener(delegate { TwitchTextChatPreface(inputField_ChatPreface); });
        inputField_ChatPreface.OnDeselect(new BaseEventData(EventSystem.current));
        // inputField_ChatPreface.OnDeselect(delegate { OnChatPrefaceDeselect(inputField_ChatPreface); });
    }

    void TwitchChannelName( InputField _change )
    {
        if(MainData)
        {
            MainData.TwitchChannel = _change.text;
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
        uiText_TextPreface.text = "Twitch Command Preface : !" + MainData.ChatPreface;

        if (MainData.ChatPreface == DEFAULT_CHAT_PREFACE) uiText_TextPreface.text += " (Default)";
    }

    bool ChatPrefaceDeselected = true;
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
    }
}
