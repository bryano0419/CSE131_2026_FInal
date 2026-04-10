using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaylistProject
{
    public class DictPlaylist : IPlaylist
    {
        // Dictionary for O(1) lookups by Title
        // List to maintain the actual order of songs
        private Dictionary<string, Song> _songDict = new Dictionary<string, Song>(StringComparer.OrdinalIgnoreCase);
        private List<string> _order = new List<string>();
        private int _currentIndex = 0;

        public void AddSong(Song song)
        {
            if (song == null) return;
            
            // Allow duplicates in the list but update/store in dict
            // To truly support duplicates in a Dictionary, we use a unique key
            string uniqueKey = $"{song.Title}_{Guid.NewGuid()}"; 
            
            // For the sake of this assignment's simple "Remove by Title" requirement:
            _songDict[song.Title] = song; 
            _order.Add(song.Title);
        }

        public bool RemoveSong(Song song)
        {
            if (song == null || !_songDict.ContainsKey(song.Title)) return false;

            // Remove from the order list (O(n))
            int index = _order.FindIndex(t => t.Equals(song.Title, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                _order.RemoveAt(index);
                // Adjust playback pointer
                if (index < _currentIndex) _currentIndex--;
                
                // Only remove from dictionary if no other instances exist in the order list
                if (!_order.Contains(song.Title, StringComparer.OrdinalIgnoreCase))
                {
                    _songDict.Remove(song.Title);
                }
                return true;
            }
            return false;
        }

        public Song? PlayNext()
        {
            if (_order.Count == 0 || _currentIndex >= _order.Count) return null;
            
            string title = _order[_currentIndex++];
            return _songDict[title];
        }

        public void Reset() => _currentIndex = 0;

        public bool MoveSongUp(Song song)
        {
            int i = _order.FindIndex(t => t.Equals(song.Title, StringComparison.OrdinalIgnoreCase));
            if (i < 0) return false;
            if (i == 0) return true;

            // Swap in the order list
            string temp = _order[i];
            _order[i] = _order[i - 1];
            _order[i - 1] = temp;
            return true;
        }

        public bool MoveSongDown(Song song)
        {
            int i = _order.FindIndex(t => t.Equals(song.Title, StringComparison.OrdinalIgnoreCase));
            if (i < 0) return false;
            if (i == _order.Count - 1) return true;

            string temp = _order[i];
            _order[i] = _order[i + 1];
            _order[i + 1] = temp;
            return true;
        }

        public void ShowPlaylist()
        {
            if (_order.Count == 0) { Console.WriteLine("Empty Playlist"); return; }
            foreach (var title in _order)
            {
                var s = _songDict[title];
                Console.WriteLine($"{s.Title} - {s.Artist} ({s.Length})");
            }
        }

        public int Length() => _order.Count;
    }
}