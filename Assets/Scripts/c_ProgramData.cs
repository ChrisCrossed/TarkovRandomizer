using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_ProgramData : MonoBehaviour
{
    #region DontDestroyOnLoad
    private static c_ProgramData instance = null;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            
            return;
        }

        print("Awake Called");
    }
    #endregion

    public string TwitchChannel;

    public string ChatPreface;

    public string ChatCommand_RegisterUser;

    string[] ChatCommands;

    // Start is called before the first frame update
    void Start()
    {
        ChatCommands = new string[5];

        print("Start Called");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
