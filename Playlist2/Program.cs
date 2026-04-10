// This program allows me to run my NotFiningPlaylist and interact with the application
// Each of your playlists should also have a Program.cs file which will create a new
// Menu class and then call menu.Display() to show the program. menu.Display() should work
// with any of the playlists that you create.

// create the playlist

// pass the playlist to the common Menu class

// call Display on that newly created menu
using System;
using PlaylistProject;

namespace PlaylistProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. create the playlist
            // Make sure this matches the 'public class' name in your other file exactly!
            IPlaylist myPlaylist = new LinkedPlaylist();

            // 2. pass the playlist to the common Menu class
            Menu mainMenu = new Menu(myPlaylist);

            // 3. call Display on that newly created menu
            mainMenu.Display();
        }
    }
}