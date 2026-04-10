using System;
using System.Collections.Generic;

namespace PlaylistProject
{
    public class LinkedPlaylist : IPlaylist
    {
        // Internal data structure changed to LinkedList
        private LinkedList<Song> _songs = new LinkedList<Song>();
        
        // We use a Node pointer instead of an integer index
        private LinkedListNode<Song>? _currentTrack = null;

        public void AddSong(Song song)
        {
            _songs.AddLast(song);
        }

        public bool RemoveSong(Song song)
        {
            var node = FindNodeByTitle(song.Title);
            if (node == null) return false;

            // If we remove the song currently being played, move pointer back
            if (_currentTrack == node)
                _currentTrack = node.Previous;

            _songs.Remove(node);
            return true;
        }

        public Song? PlayNext()
        {
            if (_songs.Count == 0) return null;

            // Start at the beginning if we haven't played anything yet
            if (_currentTrack == null)
                _currentTrack = _songs.First;
            else
                _currentTrack = _currentTrack.Next;

            return _currentTrack?.Value;
        }

        public void Reset() => _currentTrack = null;

        public bool MoveSongUp(Song song)
        {
            var node = FindNodeByTitle(song.Title);
            if (node == null) return false;
            if (node.Previous == null) return true; // Already at top

            // Swap values with the previous node
            var temp = node.Value;
            node.Value = node.Previous.Value;
            node.Previous.Value = temp;
            return true;
        }

        public bool MoveSongDown(Song song)
        {
            var node = FindNodeByTitle(song.Title);
            if (node == null) return false;
            if (node.Next == null) return true; // Already at bottom

            // Swap values with the next node
            var temp = node.Value;
            node.Value = node.Next.Value;
            node.Next.Value = temp;
            return true;
        }

        public void ShowPlaylist()
        {
            if (_songs.Count == 0)
            {
                Console.WriteLine("Empty Playlist");
                return;
            }
            foreach (var s in _songs)
                Console.WriteLine($"{s.Title} - {s.Artist} ({s.Length})");
        }

        public int Length() => _songs.Count;

        // Helper to find the Node since LinkedList doesn't use indices
        private LinkedListNode<Song>? FindNodeByTitle(string title)
        {
            var current = _songs.First;
            while (current != null)
            {
                if (current.Value.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    return current;
                current = current.Next;
            }
            return null;
        }
    }
}