using NUnit.Framework;
using System;
using PlaylistProject; // Make sure this matches your other files

[TestFixture]
public class FunctionalTests
{
    [Test]
    public void TestAddSong()
    {
        var playlist = new ListPlaylist();
        var song = new Song() { Artist = "Rick Astley", Length = 1.2, Title = "Never Gonna Give You Up" };
        playlist.AddSong(song);
        
        Assert.That(playlist.Length(), Is.EqualTo(1));
    }

    [Test]
    public void TestRemoveSong()
    {
        var playlist = new ListPlaylist();
        var song = new Song() { Artist = "Rick Astley", Length = 1.2, Title = "Never Gonna Give You Up" };
        playlist.AddSong(song);

        // FIX: Pass a Song object, not a string
        Assert.That(playlist.RemoveSong(new Song { Title = "Always Gonna Give You Up" }), Is.False);
        Assert.That(playlist.Length(), Is.EqualTo(1));

        // FIX: Pass a Song object, not a string
        Assert.That(playlist.RemoveSong(new Song { Title = "Never Gonna Give You Up" }), Is.True);
        Assert.That(playlist.Length(), Is.EqualTo(0));
    }

    [Test]
    public void TestPlayNextAndReset()
    {
        var playlist = new ListPlaylist();
        playlist.AddSong(new Song() { Title = "Song 1" });
        playlist.AddSong(new Song() { Title = "Song 2" });

        Assert.That(playlist.PlayNext()?.Title, Is.EqualTo("Song 1"));
        Assert.That(playlist.PlayNext()?.Title, Is.EqualTo("Song 2"));
        Assert.That(playlist.PlayNext(), Is.Null); // End of list

        playlist.Reset();
        Assert.That(playlist.PlayNext()?.Title, Is.EqualTo("Song 1"));
    }

    [Test]
    public void TestMoveSongUp()
    {
        var playlist = new ListPlaylist();
        playlist.AddSong(new Song() { Title = "Song 1" });
        playlist.AddSong(new Song() { Title = "Song 2" });

        // FIX: Pass a Song object, not a string
        Assert.That(playlist.MoveSongUp(new Song { Title = "Song 2" }), Is.True);
        playlist.Reset();
        Assert.That(playlist.PlayNext()?.Title, Is.EqualTo("Song 2"));

        // Edge Case: Move top song up (should return true but stay at top)
        Assert.That(playlist.MoveSongUp(new Song { Title = "Song 2" }), Is.True);
    }
}