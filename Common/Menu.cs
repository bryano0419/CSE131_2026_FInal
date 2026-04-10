public class Menu
{
    private readonly IPlaylist _playlist;

    /// <summary>
    /// Creates a menu
    /// </summary>
    /// <param name="playlist">The playlist to be used for this menu</param>
    public Menu(IPlaylist playlist)
    {
        _playlist = playlist;
    }

    public void Display()
    {
        while (true)
        {
            Console.Clear(); // Comment out this line to show the full menu history 
            Console.WriteLine($"=== Current Playlist ({_playlist.Length()}) ===");
            _playlist.ShowPlaylist();
            Console.WriteLine("============================");
            Console.WriteLine("Playlist Menu:");
            Console.WriteLine("1. Add Song");
            Console.WriteLine("2. Remove Song");
            Console.WriteLine("3. Play Next Song");
            Console.WriteLine("4. Move Song Up");
            Console.WriteLine("5. Move Song Down");
            Console.WriteLine("0. Exit");

            Console.Write("Enter choice: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter song title: ");
                    var title = Console.ReadLine();
                    Console.Write("Enter song length (in seconds): ");
                    var lengthInput = Console.ReadLine();
                    double.TryParse(lengthInput, out double length);
                    Console.Write("Enter artist name: ");
                    var artist = Console.ReadLine();
                    _playlist.AddSong(new Song { Title = title, Length = length, Artist = artist });
                    break;
                case "2":
                    Console.Write("Enter song title to remove: ");
                    title = Console.ReadLine();
                    var removed = _playlist.RemoveSong(new Song { Title = title });
                    Console.WriteLine(removed ? "Removed successfully." : "Song not found.");
                    break;
                case "3":
                    var nextSong = _playlist.PlayNext();
                    if (nextSong != null)
                    {
                        Console.WriteLine($"Now playing: {nextSong.Title} by {nextSong.Artist}");
                    }
                    else
                    {
                        Console.WriteLine("Playlist is empty.");
                    }
                    break;
                case "4":
                    Console.Write("Enter song title to move up: ");
                    title = Console.ReadLine();
                    var movedUp = _playlist.MoveSongUp(new Song { Title = title });
                    Console.WriteLine(movedUp ? "Moved up." : "Song not found.");
                    break;
                case "5":
                    Console.Write("Enter song title to move down: ");
                    title = Console.ReadLine();
                    var movedDown = _playlist.MoveSongDown(new Song { Title = title });
                    Console.WriteLine(movedDown ? "Moved down." : "Song not found.");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            
            Console.WriteLine("Operation complete, press any <enter/return> to continue...");
            Console.ReadLine();
        }
    }
}