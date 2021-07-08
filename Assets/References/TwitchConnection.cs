/*This script was created by Hardytier of www.youtube.com/hardytier && www.twitch.tv/hardytier
 * It would be a great help if you could pop on by either of those and hang out for a while!
 * Much of this script was pulled from many other sources, none of which required permission to use or redistribute.
 * Since you have purchased this from me directly, let this notice serve as an official license to use, but not redistribute, this script.
 * Please reference the corresponding youtube video regarding this framework: https://youtu.be/4lekE-Sd10o
 */

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using System.Linq;
//using TwitchLib.Api.Core.HttpCallHandlers;
//using TwitchLib.Client;
//using TwitchLib.Client.Events;
//using TwitchLib.Client.Models;
using System.Threading.Tasks;



public class TwitchConnection : MonoBehaviour
{

    private TcpClient twitchClient;

    private StreamReader reader;
    private StreamWriter writer;

    public string username, password, channelName; //Pw from https://twitchapps.com/tmi
    private GameObject playerObject;

    private List<GameObject> users;

    GameObject go;
    private int randomNumber;



    public List<string> usersInBattle = new List<string>();

    private bool isRegisteredCheck;

    private float randomTimer = 0.0f;
    private float ytTimer = 0.0f;
    private float addUserPoints = 0.0f;


    void Start()
    {
        randomTimer = 30.0f; //First random message happens at bot start + 30 seconds.

        Connect();

        users = new List<GameObject>();
        playerObject = GameObject.Find("user");
        if (playerObject != null)
        {
            print("Found user Object");
        }
        else
        {
            print("Could not find user Object");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!twitchClient.Connected)
        {
            Connect();
        }

        ReadChat();

        //Timer decreases.
        randomTimer -= Time.deltaTime;
        ytTimer -= Time.deltaTime;

        //Timer increases.
        addUserPoints += Time.deltaTime;

        if (randomTimer <= 0.0f)
        {
            randomNumber = UnityEngine.Random.Range(0, 2);
            if (randomNumber == 0)
            {
                SendPublicChatMessage("Did you know that this message was on a semi-random timer?");

                randomNumber = UnityEngine.Random.Range(0, 4);
                if (randomNumber == 0)
                {
                    randomTimer = 45.0f;
                }

                if (randomNumber == 1)
                {
                    randomTimer = 60.0f;
                }

                if (randomNumber == 2)
                {
                    randomTimer = 75.0f;
                }

                if (randomNumber == 3)
                {
                    randomTimer = 90.0f;
                }

            }
            if (randomNumber == 1)
            {
                SendPublicChatMessage("Bee-boop.");

                randomNumber = UnityEngine.Random.Range(0, 4);
                if (randomNumber == 0)
                {
                    randomTimer = 45.0f;
                }

                if (randomNumber == 1)
                {
                    randomTimer = 60.0f;
                }

                if (randomNumber == 2)
                {
                    randomTimer = 75.0f;
                }

                if (randomNumber == 3)
                {
                    randomTimer = 90.0f;
                }

            }

            //Specific Timer Printouts
            if (ytTimer <= 0.0f)
            {
                SendPublicChatMessage("Subscribing @ www.youtube.com/Hardytier will give you notifications for all kinds of cool game playing and game making things! You should do that. <3");
                ytTimer = 300.0f;
            }
        }


        if (addUserPoints >= 10.0f)
        {
            if (users != null) // This may or may not be doing anything since the i in the for loop is based on the Count.
            {
                for (int i = 0; i < users.Count; i++)
                {
                    users[i].GetComponent<PlayerData>().AddPoints(10);
                    addUserPoints = 0.0f;
                }
            }
        }
    }

    private void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream()) { NewLine = "\r\n", AutoFlush = true };


        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8 * :" + username);
        writer.WriteLine("JOIN #" + channelName);
        writer.Flush();

    }




    private void ReadChat()
    {


        if (twitchClient.Available > 0)
        {
            var message = reader.ReadLine(); //Read in the current message

            if (message.Contains("PRIVMSG"))
            {

                //Get the users name by splitting it from the string.
                var splitPoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitPoint);
                chatName = chatName.Substring(1);


                //Get the users message by splitting it from the string.
                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);
                print(String.Format("{0}: {1}", chatName, message));



                //Registration verification process.
                if (GameObject.Find(chatName) == false)
                {
                    isRegisteredCheck = false;
                }
                else if (GameObject.Find(chatName) == true)
                {
                    isRegisteredCheck = true;
                }

                //Begin separation of registered vs unregistered commands.
                if (isRegisteredCheck == true)
                { //Commands for registered users go here.
                    if (message == "!hello")
                    {
                        SendPublicChatMessage("Hello, " + chatName);
                    }

                    //Commands for users with points.
                    // - Find their info to confirm points.
                    PlayerData userScript = GameObject.Find(chatName).GetComponent<PlayerData>();
                    // - Check points against the command request.
                    if ((message == "!pog") && (userScript.userPoints >= 10))
                    {
                        userScript.SubPoints(10);
                        SendPublicChatMessage("PogChamp PogChamp PogChamp PogChamp PogChamp");
                    }
                    // - Another example, 20 point cost.
                    if ((message == "!respect") && (userScript.userPoints >= 20))
                    {
                        userScript.SubPoints(20);
                        SendPublicChatMessage("F");
                        SendPublicChatMessage("F");
                    }

                }
                else if (isRegisteredCheck == false)
                { //Commands for unregistered users go here.
                    if (message == "!msg")
                    {
                        SendPublicChatMessage("This is a test message for anyone to use!");
                    }

                    if (message == "!join")
                    {
                        SendPublicChatMessage("You have not yet registered and can not join the battle.");
                    }

                    if (message == "!register")
                    {
                        //int userLength = users.Length;
                        bool isRegistered = false;

                        print("Before registry search.");

                        bool isDone = false;
                        int positionCounter = 0;



                        print("There are " + users.Count.ToString() + " users registered.");

                        for (int i = 0; i < users.Count; i++)
                        {
                            positionCounter++;
                            if (users[i].name != chatName) //Position taken, remove this printout later.
                            {
                                print("Position " + positionCounter + " has been taken by " + users[i].name.ToString() + ". Attempting next position...");
                            }
                            else if (users[i].name == chatName) //Already registered.
                            {
                                print("You have already registered. Your user ID is " + positionCounter);
                                isRegistered = true;
                                SendPublicChatMessage(chatName + " is already registered.");
                            }

                        }

                        isDone = true;

                        if ((isRegistered == false) && (isDone == true))
                        {
                            positionCounter++;
                            //Create a GameObject for the new player then name it after that player.
                            go = Instantiate(playerObject, new Vector3(0, 0, 0), Quaternion.identity);
                            go.name = chatName;
                            go.AddComponent<PlayerData>();
                            users.Add(go);
                            PlayerData playerData = go.GetComponent<PlayerData>();
                            playerData.userID = positionCounter;
                            print("Successfully added UserData for " + chatName + ". User ID " + positionCounter + ".");
                            SendPublicChatMessage(chatName + " has been added to the game. GLHF!");
                        }
                        else
                        {
                            //Do nothing if those conditions are not met together.
                        }

                    }
                }

                //Exclusive Owner Commands
                if (chatName == "hardytier")
                {
                    if (message.Contains("!say"))
                    {
                        splitPoint = message.IndexOf("!say", 2);
                        message = message.Substring(splitPoint + 6);
                        SendPublicChatMessage(message);
                    }

                    if (message == "!emote")
                    {
                        SendPublicChatMessage("/emoteonly");
                    }

                    if (message == "!emoteoff")
                    {
                        SendPublicChatMessage("/emoteonlyoff");
                    }

                }

                if (message == "!test")
                {

                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].name == chatName)
                        {
                            print("You are recognized by the system. Test successful. Your name is " + chatName);
                            print("There are " + users.Count.ToString() + " registered by the system.");
                            SendPublicChatMessage("Test initialized. You are recognized by the system. Your name is " + chatName + " and there are " + users.Count.ToString() + " total registered users.");
                        }

                        else
                        {
                            //print("** Else branch, !test command.");
                            //Do nothing 
                        }
                    }
                }

                //Roll test ---------------------------------------

                if (message == "!roll")
                {
                    randomNumber = UnityEngine.Random.Range(0, 3);
                    if (randomNumber == 0)
                    {
                        print("You rolled a 0!");
                        SendPublicChatMessage("You rolled a 0!");
                    }
                    if (randomNumber == 1)
                    {
                        print("You rolled a 1!");
                        SendPublicChatMessage("You rolled a 1!");
                    }
                    if (randomNumber == 2)
                    {
                        print("You rolled a 2!");
                        SendPublicChatMessage("You rolled a 2!");
                    }
                }
                //End Roll test ---------------------------------------


                //Clear go info after each message.
                go = null;
            }

        }
    }


    public void SendIrcMessage(string message)
    {
        try
        {
            writer.WriteLine(message);
            writer.Flush();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void SendPublicChatMessage(string message)
    {
        try
        {
            SendIrcMessage(":" + username + "!" + username + "@" + username +
            ".tmi.twitch.tv PRIVMSG #" + channelName + " :" + message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    /* -- test without Main active.
    static void Main(string[] args)
    {
        // Initialize and connect to Twitch chat
        IrcClient irc = new IrcClient("irc.twitch.tv", 6667,
            "pokebottier", "oauth:fbvp68b8ml2js6zwncxhexr6vfgro6", "hardytier");

        // Ping to the server to make sure this bot stays connected to the chat
        // Server will respond back to this bot with a PONG (without quotes):
        // Example: ":tmi.twitch.tv PONG tmi.twitch.tv :irc.twitch.tv"
        PingSender ping = new PingSender(irc);
        ping.Start();


        /*
        // Listen to the chat until program exits
        while (true)
        {
            // Read any message from the chat room
            string message = irc.ReadMessage();
            Console.WriteLine(message); // Print raw irc messages

            if (message.Contains("PRIVMSG"))
            {
                // Messages from the users will look something like this (without quotes):
                // Format: ":[user]![user]@[user].tmi.twitch.tv PRIVMSG #[channel] :[message]"

                // Modify message to only retrieve user and message
                int intIndexParseSign = message.IndexOf('!');
                string userName = message.Substring(1, intIndexParseSign - 1); // parse username from specific section (without quotes)
                                                                               // Format: ":[user]!"
                                                                               // Get user's message
                intIndexParseSign = message.IndexOf(" :");
                message = message.Substring(intIndexParseSign + 2);

                Console.WriteLine(message); // Print parsed irc message (debugging only)

                // Broadcaster commands
                if (userName.Equals("hardytier"))
                {
                    if (message.Equals("!exitbot"))
                    {
                        irc.SendPublicChatMessage("Bye! Have a beautiful time!");
                        Environment.Exit(0); // Stop the program
                    }
                }

                // General commands anyone can use
                if (message.Equals("!hello"))
                {
                    irc.SendPublicChatMessage("Hello World!");
                }
            }
        }
        
    }
*/



}
