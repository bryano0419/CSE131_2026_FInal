using NUnit.Framework;
using System.Diagnostics;
using System;
using PlaylistProject; 

public class PerformanceTests
{
    private readonly int[] _testSizes = { 10, 100, 1000, 10000, 100000 };

    [Test]
    public void RunAllPerformanceTests()
    {
        foreach (int size in _testSizes)
        {
            Console.WriteLine($"--- Testing LinkedPlaylist Size: {size} ---");
            TestAddSongPerformance(size);
            TestRemoveSongPerformance(size);
            TestMoveSongPerformance(size);
            Console.WriteLine();
        }
    }

    private void TestAddSongPerformance(int operations)
    {
        // TARGET THE NEW LINKED LIST CLASS
        var playlist = new LinkedPlaylist(); 
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
        // TARGET THE NEW LINKED LIST CLASS
        var playlist = new LinkedPlaylist();
        for (int i = 0; i < size; i++)
        {
            playlist.AddSong(new Song() { Title = $"Song{i}" });
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        playlist.RemoveSong(new Song { Title = $"Song{size - 1}" });
        
        stopwatch.Stop();
        Console.WriteLine($"RemoveSong (Worst Case): {stopwatch.Elapsed.TotalMilliseconds} ms");
    }

    private void TestMoveSongPerformance(int size)
    {
        // TARGET THE NEW LINKED LIST CLASS
        var playlist = new LinkedPlaylist();
        for (int i = 0; i < size; i++)
        {
            playlist.AddSong(new Song() { Title = $"Song{i}" });
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        playlist.MoveSongUp(new Song { Title = $"Song{size - 1}" });
        
        stopwatch.Stop();
        Console.WriteLine($"MoveSongUp (Worst Case): {stopwatch.Elapsed.TotalMilliseconds} ms");
    }
}

/* * PERFORMANCE ANALYSIS - WEEK 12 (Linked List Implementation)
 * -----------------------------------------------------------
 * 1. AddSong: O(1) 
 * LinkedList.AddLast is constant time because the list maintains 
 * a pointer to the Tail node.
 * * 2. RemoveSong: O(n) 
 * Even though the actual node removal is O(1), we must perform a 
 * linear search (O(n)) to find the specific title in the chain.
 * * 3. PlayNext: O(1) 
 * Moving from one node to 'node.Next' is a simple pointer 
 * reference and does not depend on the size of the playlist.
 * * 4. MoveSongUp/Down: O(n) 
 * Similar to RemoveSong, we must traverse the list to find the 
 * node before we can re-link the pointers.
 *
 * WEEK 12 vs WEEK 11 Comparison:
 * In Week 11 (List), removing or moving items required shifting 
 * elements in memory (O(n)). In Week 12 (LinkedList), we don't 
 * shift memory, but we still have O(n) time because we must 
 * search for the node first.
 */