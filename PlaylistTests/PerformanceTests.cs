using NUnit.Framework;
using System.Diagnostics;

public class PerformanceTests
{
    [Test]
    public void TestAddSongPerformance()
    {
        var playlist = new NoDataStructurePlaylist();
        var stopwatch = new Stopwatch();
        // TODO use this size as an example, but other functions may require a different number of operations
        int operations = 10000;
        stopwatch.Start();
        for (int i = 0; i < operations; i++)
        {
            playlist.AddSong(new Song() { Title = $"Song{i}", Artist = "Test", Length = 3.0 });
        }
        stopwatch.Stop();
        Console.WriteLine($"AddSong: {stopwatch.ElapsedMilliseconds} ms for {operations} operations");
    }
    
    // TODO Add more tests for all the playlists (or one at a time)...

}

