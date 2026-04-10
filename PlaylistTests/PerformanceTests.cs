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
            Console.WriteLine($"--- Testing DictPlaylist Size: {size} ---");
            TestAddSongPerformance(size);
            TestRemoveSongPerformance(size);
            TestMoveSongPerformance(size);
            Console.WriteLine();
        }
    }

    private void TestAddSongPerformance(int operations)
    {
        // TARGETING WEEK 13 DICTIONARY IMPLEMENTATION
        var playlist = new DictPlaylist(); 
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
        // TARGETING WEEK 13 DICTIONARY IMPLEMENTATION
        var playlist = new DictPlaylist();
        for (int i = 0; i < size; i++)
        {
            playlist.AddSong(new Song() { Title = $"Song{i}" });
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        // Dictionary lookup is O(1), but List removal is O(n)
        playlist.RemoveSong(new Song { Title = $"Song{size - 1}" });
        
        stopwatch.Stop();
        Console.WriteLine($"RemoveSong (Worst Case): {stopwatch.Elapsed.TotalMilliseconds} ms");
    }

    private void TestMoveSongPerformance(int size)
    {
        // TARGETING WEEK 13 DICTIONARY IMPLEMENTATION
        var playlist = new DictPlaylist();
        for (int i = 0; i < size; i++)
        {
            playlist.AddSong(new Song() { Title = $"Song{i}" });
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        // Finding the index in the order list is O(n)
        playlist.MoveSongUp(new Song { Title = $"Song{size - 1}" });
        
        stopwatch.Stop();
        Console.WriteLine($"MoveSongUp (Worst Case): {stopwatch.Elapsed.TotalMilliseconds} ms");
    }
}

/* * PERFORMANCE ANALYSIS - WEEK 11 (List Implementation)
 * ---------------------------------------------------
 * 1. AddSong: O(1) - Adding to the end of a List is constant time. 
 * 2. RemoveSong: O(n) - Requires linear search and element shifting.
 * 3. PlayNext: O(1) - Simple index access.
 * 4. MoveSongUp: O(n) - Requires linear search before swapping.
 */

/* * PERFORMANCE ANALYSIS - WEEK 12 (Linked List Implementation)
 * -----------------------------------------------------------
 * 1. AddSong: O(1) - Constant time tail insertion.
 * 2. RemoveSong: O(n) - O(n) search to find the node, though removal is O(1).
 * 3. PlayNext: O(1) - Direct pointer reference to node.Next.
 * 4. MoveSongUp/Down: O(n) - Must traverse the chain to find the node.
 */

/* * PERFORMANCE ANALYSIS - WEEK 13 (Dictionary Implementation)
 * -----------------------------------------------------------
 * 1. AddSong: O(1) 
 * Dictionary insertion and List appending are both O(1) on average.
 *
 * 2. RemoveSong: O(n) 
 * While Dictionary lookup is O(1), maintaining a sequence requires a List. 
 * Finding and removing the title from the List remains O(n).
 *
 * 3. PlayNext: O(1) 
 * Dictionary lookup by key and List index access are both constant time.
 *
 * 4. MoveSongUp/Down: O(n) 
 * We must perform a linear search (O(n)) in the "order" list to find 
 * the current position before we can swap titles.
 *
 * WEEK 13 vs PREVIOUS WEEKS:
 * The Dictionary provides the fastest possible lookup by Title. However, 
 * because a playlist is an ordered collection, we are still tied to O(n) 
 * for operations that modify the sequence (Remove/Move) because the 
 * "order" list must be searched.
 */