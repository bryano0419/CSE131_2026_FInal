using System;
using System.Collections.Generic;

namespace PlaylistProject
{
    /*
     * 1. Name: [Your Name]
     * 2. Assignment Name: Week 11 Prove: Final Project - Draft Submission 1
     * 3. Assignment Description: 
     * Playlist implementation using a List<Song> (Dynamic Array). 
     * This class implements the IPlaylist interface to ensure compatibility 
     * with the common Menu class.
     */

    public class ListPlaylist : IPlaylist
    {
        private List<Song> _songs = new List<Song>();
        private int _currentIndex = 0;

        // Requirement: Adds a Song object to the end of the playlist.
        public void AddSong(Song song)
        {
            _songs.Add(song);
        }

        // Requirement: Removes the first matching song based on Title.
        // Interface requires a Song object parameter.
        public bool RemoveSong(Song song)
        {
            if (_songs.Count == 0 || song == null) return false;

            int index = _songs.FindIndex(s => s.Title.Equals(song.Title, StringComparison.OrdinalIgnoreCase));
            
            if (index != -1)
            {
                _songs.RemoveAt(index);
                // Adjust playback pointer if we removed a song before the current playing song
                if (index < _currentIndex) _currentIndex--;
                return true;
            }
            return false;
        }

        // Requirement: Returns the next song and increments the sequence.
        public Song? PlayNext()
        {
            if (_songs.Count == 0 || _currentIndex >= _songs.Count)
                return null;

            return _songs[_currentIndex++];
        }

        // Requirement: Resets playback to the beginning.
        public void Reset()
        {
            _currentIndex = 0;
        }

        // Requirement: Swaps matching song with the one BEFORE it.
        public bool MoveSongUp(Song song)
        {
            if (song == null) return false;

            int i = _songs.FindIndex(s => s.Title.Equals(song.Title, StringComparison.OrdinalIgnoreCase));
            
            if (i < 0) return false;   // Not found
            if (i == 0) return true;   // Already at top, do nothing

            // Swap
            Song temp = _songs[i];
            _songs[i] = _songs[i - 1];
            _songs[i - 1] = temp;
            return true;
        }

        // Requirement: Swaps matching song with the one AFTER it.
        public bool MoveSongDown(Song song)
        {
            if (song == null) return false;

            int i = _songs.FindIndex(s => s.Title.Equals(song.Title, StringComparison.OrdinalIgnoreCase));
            
            if (i < 0) return false;               // Not found
            if (i == _songs.Count - 1) return true; // Already at bottom, do nothing

            // Swap
            Song temp = _songs[i];
            _songs[i] = _songs[i + 1];
            _songs[i + 1] = temp;
            return true;
        }

        // Requirement: Displays all songs in Title - Artist (Length) format.
        public void ShowPlaylist()
        {
            if (_songs.Count == 0)
            {
                Console.WriteLine("Empty Playlist");
                return;
            }

            foreach (var s in _songs)
            {
                Console.WriteLine($"{s.Title} - {s.Artist} ({s.Length})");
            }
        }

        // Requirement: Returns current number of songs.
        public int Length()
        {
            return _songs.Count;
        }
    }
}

/* * PERFORMANCE ANALYSIS - WEEK 11 (List Implementation)
 * ---------------------------------------------------
 * 1. AddSong: O(1) - Adding to the end of a List is constant time. 
 * My results stayed consistent even as the size grew to 100,000.
 *
 * 2. RemoveSong: O(n) - We have to search the list for the title (Linear Search). 
 * My results showed a significant increase in time as the size grew.
 *
 * 3. PlayNext: O(1) - Accessing a list by index is constant time. 
 * The size of the playlist does not affect speed here.
 *
 * 4. MoveSongUp: O(n) - Requires a linear search to find the song's index 
 * before the swap can happen. Time increases linearly with playlist size.
 */