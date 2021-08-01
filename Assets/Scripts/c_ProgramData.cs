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

            WriteData();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChatCommands = new string[5];

        print("Start Called");

        CheckSaveFile();

        AddUser("ChrisCrossed");
        /*
        AddUser("Auston");
        AddUser("Auston");
        AddUser("1337Hacker");
        AddUser("CoolGuy42");
        AddUser("ChrisCrossed");
        AddUser("TheONE");
        AddUser("ImCOOOL");
        */

        userDataList = userDataList.OrderBy(o => o.UserName).ToList();
    }

    

    bool DoesUserNameExist(string _userName)
    {
        foreach(UserData user in userDataList)
        {
            if(user.UserName == _userName) return true;
        }

        return false;
    }

    string Folder;
    string FilePath;
    void WriteData()
    {
        if(FilePath == null || FilePath == "") FilePath = Folder + "users.csv";

        StreamWriter writer = new StreamWriter(FilePath, false);

        using (writer)
        {
            foreach (UserData data in userDataList)
            {
                writer.Write(data.UserName + "," + data.Score + System.Environment.NewLine);
                print("Wrote " + data.UserName);

                Debug.Log($"CSV File written to \"{FilePath}\"");

                writer.Close();
            }
        }

        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif
    }

    void AddData()
    {

    }

    void ReadData()
    {
        FilePath = Folder + "users.csv";
        StreamReader reader = new StreamReader(FilePath);
        print(reader.ReadLine());

        reader.Close();

        /*
        string textOutput = reader.ReadToEnd();

        print(textOutput);
        */
    }

    void CheckSaveFile()
    {
        // string folder = "%UserProfile%/TarkovRandomizer/";
        Folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments).Replace("\\", "/");
        Folder += "/TarkovRandomizer/";

        if (!System.IO.Directory.Exists(Folder)) System.IO.Directory.CreateDirectory(Folder);

        FilePath = Folder + "users.csv";
        if (!System.IO.File.Exists(FilePath))
        {
            // FilePath = Path.Combine(FilePath);

            System.IO.File.Create(FilePath);
        }

        // Read data if it exists
        ReadData();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
