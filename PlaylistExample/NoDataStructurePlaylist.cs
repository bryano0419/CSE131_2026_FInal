using System;

// Your Playlist should implement the IPlaylist interface
public class NoDataStructurePlaylist : IPlaylist
{
    // You should have all the methods defined by the IPlaylist interface
    public void AddSong(Song song)
    {
        // actually, I should do some work here, but what if I don't have a data structure
    }

    public bool RemoveSong(Song song)
    {
        // there's nothing to remove
        return false;
    }

    public Song? PlayNext()
    {
        // there is no next song... bwahahahaha!
        return null;
    }

    public void Reset()
    {
        // I can get behind resetting thing :D
    }

    public bool MoveSongUp(Song song)
    {
        // no move for you!
        return false;
    }

    public bool MoveSongDown(Song song)
    {
        // no move for you!
        return false;
    }

    public void ShowPlaylist()
    {
        // hehehe this will trick users into thinking there are songs XD
        Console.WriteLine("Tiptoe Through the Tulips");
        Console.WriteLine("Never Gonna Give You Up");
    }

    public int Length()
    {
        // I'm only off by one...
        return 1;
    }
}