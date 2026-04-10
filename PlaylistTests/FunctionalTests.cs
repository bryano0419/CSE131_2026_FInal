using NUnit.Framework;
using System;

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

        // Test failing to remove (wrong title)
        Assert.That(playlist.RemoveSong("Always Gonna Give You Up"), Is.False);
        Assert.That(playlist.Length(), Is.EqualTo(1));

        // Test successful removal
        Assert.That(playlist.RemoveSong("Never Gonna Give You Up"), Is.True);
        Assert.That(playlist.Length(), Is.EqualTo(0));
    }

    [Test]
    public void TestPlayNextAndReset()
    {
        var playlist = new ListPlaylist();
        playlist.AddSong(new Song() { Title = "Song 1" });
        playlist.AddSong(new Song() { Title = "Song 2" });

        Assert.That(playlist.PlayNext().Title, Is.EqualTo("Song 1"));
        Assert.That(playlist.PlayNext().Title, Is.EqualTo("Song 2"));
        Assert.That(playlist.PlayNext(), Is.Null); // End of list

        playlist.Reset();
        Assert.That(playlist.PlayNext().Title, Is.EqualTo("Song 1"));
    }

    [Test]
    public void TestMoveSongUp()
    {
        var playlist = new ListPlaylist();
        playlist.AddSong(new Song() { Title = "Song 1" });
        playlist.AddSong(new Song() { Title = "Song 2" });

        // Move 2nd song to 1st position
        Assert.That(playlist.MoveSongUp("Song 2"), Is.True);
        playlist.Reset();
        Assert.That(playlist.PlayNext().Title, Is.EqualTo("Song 2"));

        // Edge Case: Move top song up (should return true but stay at top)
        Assert.That(playlist.MoveSongUp("Song 2"), Is.True);
    }
}