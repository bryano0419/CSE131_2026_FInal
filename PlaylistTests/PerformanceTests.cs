using NUnit.Framework;
using System.Diagnostics;
using System;
using PlaylistProject; // Ensure this matches your namespace

public class PerformanceTests
{
    // The sizes required by the assignment
    private readonly int[] _testSizes = { 10, 100, 1000, 10000, 100000 };

    [Test]
    public void RunAllPerformanceTests()
    {
        foreach (int size in _testSizes)
        {
            Console.WriteLine($"--- Testing Playlist Size: {size} ---");
            TestAddSongPerformance(size);
            TestRemoveSongPerformance(size);
            TestMoveSongPerformance(size);
            Console.WriteLine();
        }
    }

    private void TestAddSongPerformance(int operations)
    {
        var playlist = new ListPlaylist(); // Changed from NoDataStructurePlaylist
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        for (int i = 0; i < operations; i++)
        {
            playlist.AddSong(new Song() { Title = $"Song{i}", Artist = "Test", Length = 3.0 });
        }
        stopwatch.Stop();
        
        Console.WriteLine($"AddSong: {stopwatch.ElapsedMilliseconds} ms for {operations} operations");
    }

    private void TestRemoveSongPerformance(int size)
    {
        var playlist = new ListPlaylist();
        // Setup the playlist first
        for (int i = 0; i < size; i++)
        {
            playlist.AddSong(new Song() { Title = $"Song{i}" });
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        // Remove the very last song (worst case scenario for List performance)
        playlist.RemoveSong(new Song { Title = $"Song{size - 1}" });
        
        stopwatch.Stop();
        Console.WriteLine($"RemoveSong (Worst Case): {stopwatch.Elapsed.TotalMilliseconds} ms");
    }

    private void TestMoveSongPerformance(int size)
    {
        var playlist = new ListPlaylist();
        for (int i = 0; i < size; i++)
        {
            playlist.AddSong(new Song() { Title = $"Song{i}" });
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        // Move a song from the end towards the front
        playlist.MoveSongUp(new Song { Title = $"Song{size - 1}" });
        
        stopwatch.Stop();
        Console.WriteLine($"MoveSongUp (Worst Case): {stopwatch.Elapsed.TotalMilliseconds} ms");
    }
}