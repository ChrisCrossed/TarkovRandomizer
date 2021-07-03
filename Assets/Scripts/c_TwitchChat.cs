using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using UnityEngine.UI;

public class c_TwitchChat : MonoBehaviour
{
    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;

    //Get the password from https://twitchapps.com/tmi
    string username = "chrischrisbot";
    string password = "oauth:7acr7m78whhu81g6uab24wraaeekof";
    string channelName = "HoffmanTV";

    string textPreface = "tr";

    // Start is called before the first frame update
    void Start()
    {
        channelName = channelName.ToLower();

        textPreface = "!" + textPreface;

        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if(!twitchClient.Connected)
        {
            Connect();
        }

        ReadChat();
    }

    private void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

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
            string message = reader.ReadLine(); //Read in the current message
            print(message);

            if (message.Contains("PRIVMSG"))
            {
                // Starts from character '1' (skips the ':' in the message) and searches for '!'
                int splitPoint = message.IndexOf("!", 1);

                // Creates a string bypassing the ':' character of the username who sent the message
                string chatName = message.Substring(1, splitPoint);

                //Get the users message by splitting it from the string
                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);
                print(String.Format("{0}: {1}", chatName, message));

                // Determine if there is a space in the message
                int textPrefacePoint = message.IndexOf(" ");
                // If we found a space (no space == -1), continue
                if(textPrefacePoint >= 0)
                {
                    // Gather the first batch of text
                    string textPrefaceString = message.Substring(0, textPrefacePoint);

                    // Convert to lowercase for testing
                    textPrefaceString = textPrefaceString.ToLower();

                    // If the first group of text is the same as our catcher, continue
                    if(textPrefaceString == textPreface)
                    {
                        // Print temporary output
                        print(String.Format("output: {0} / {1}", textPrefaceString, textPreface));
                    }
                }
            }
        }
    }
}
