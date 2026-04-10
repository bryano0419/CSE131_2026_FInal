/// <summary>
/// This IPlaylist interface is to define the functions that MUST be on every playlist. When a class implements
/// this interface, the common Menu class can then call these functions for all the different playlists and the
/// functionality should be more or less the same as you use the different implementations.
/// </summary>
public interface IPlaylist
{
    /// <summary>
    /// Adds the given song to the playlist. It should be added to the end after all the other
    /// songs have played.
    /// </summary>
    /// <param name="song">A song object that has been fully populated</param>
    void AddSong(Song song);

    /// <summary>
    /// Removes a song that "matches" this song from the playlist. It should only remove up to one song.
    /// It could be that this song object only has the title or title and artist populated.
    /// </summary>
    /// <param name="song">A song object that has been partially populated</param>
    bool RemoveSong(Song song);
    
    /// <summary>
    /// This should return the <c>Song</c> object in the playlist that is to play next or null if there are no
    /// more songs to play. It should always return null until either a new song is added or the <c>Reset()</c>
    /// function has been called
    /// </summary>
    /// <returns>The next song to be played or null if all songs have been played</returns>
    Song? PlayNext();

    /// <summary>
    /// Resets the play order so that the next time <c>PlayNext</c> is called, the first song will be played.
    /// </summary>
    void Reset();
    
    /// <summary>
    /// Moves the matching song up in the playlist order. If the given song is 3rd in the playlist, it should
    /// move it up to be the 2nd song. If the 3rd song was the song that was currently playing, the <c>PlayNext()</c>
    /// function should play the new 3rd song.
    /// </summary>
    /// <param name="song">A song object that has been partially populated</param>
    /// <returns>true if the song was present and was moved, otherwise false</returns>
    bool MoveSongUp(Song song);
    
    /// <summary>
    /// Moves the matching song down in the playlist order. If the given song is 3rd in the playlist, it should
    /// move it down to be the 4th song. If the 3rd song was the song that was currently playing, the <c>PlayNext()</c>
    /// function should play the 5th song.
    /// </summary>
    /// <param name="song">A song object that has been partially populated</param>
    /// <returns>true if the song was present and was moved, otherwise false</returns>
    bool MoveSongDown(Song song);

    /// <summary>
    /// Displays the playlist in order in the console
    /// </summary>
    void ShowPlaylist();
    
    /// <summary>
    /// Returns the number of songs in the playlist
    /// </summary>
    /// <returns>Number of songs</returns>
    int Length();
}