using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.Text;
using System.IO;
using UnityEditor;
using System.Linq;

public struct UserData
{
    private string _userName;
    private int _score;

    public string UserName
    {
        get => _userName;
        private set => _userName = value;
    }

    public int Score
    {
        get => _score;
        internal set =>_score = value;
    }
    
    internal UserData(string userName_, int score_)
    {
        _userName = userName_;
        _score = score_;
    }
}

public class c_ProgramData : MonoBehaviour
{
    #region DontDestroyOnLoad
    private static c_ProgramData instance = null;
    private void Awake()
    {
        if (instance == null)
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

    List<UserData> userDataList = new List<UserData>();

    // public void AddUser(string userName_) => userDataList.Add(new UserData(userName_, 50));
    public void AddUser(string userName_)
    {
        if(!DoesUserNameExist(userName_))
        {
            userDataList.Add(new UserData(userName_, 100));

            SaveData();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        ChatCommands = new string[5];

        print("Start Called");

        // UserData newData = new UserData();

        AddUser("ChrisCrossed");
        AddUser("Auston");
        AddUser("Auston");
        AddUser("1337Hacker");
        AddUser("CoolGuy42");
        AddUser("ChrisCrossed");
        AddUser("TheONE");
        // AddUser("ImCOOOL");

        userDataList = userDataList.OrderBy(o => o.UserName).ToList();
    }

    bool FirstSaveAttempt = false;
    string Folder;
    string FilePath;
    void SaveData()
    {
        if(FirstSaveAttempt)
        {
            // string folder = "%UserProfile%/TarkovRandomizer/";
            Folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments).Replace("\\", "/");
            Folder += "/TarkovRandomizer/";

            if (!System.IO.Directory.Exists(Folder)) System.IO.Directory.CreateDirectory(Folder);

            FilePath = Path.Combine(Folder, "users.csv");

            FirstSaveAttempt = false;
        }

        WriteData();
    }

    bool DoesUserNameExist(string _userName)
    {
        bool foundName = false;

        foreach(UserData user in userDataList)
        {
            if(user.UserName == _userName)
            {
                foundName = true;
                continue;
            }
        }

        return foundName;
    }

    void WriteData()
    {
        StreamWriter writer = new StreamWriter(FilePath, false);

        using (writer)
        {
            foreach (UserData data in userDataList)
                writer.Write(data.UserName + "," + data.Score + System.Environment.NewLine);
        }

        Debug.Log($"CSV File written to \"{FilePath}\"");

        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif
    }

    void AddData()
    {

    }

    void ReadData()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
