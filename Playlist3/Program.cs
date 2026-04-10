using PlaylistProject;

namespace PlaylistProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlaylist myPlaylist = new DictPlaylist();
            Menu mainMenu = new Menu(myPlaylist);
            mainMenu.Display();
        }
    }
}