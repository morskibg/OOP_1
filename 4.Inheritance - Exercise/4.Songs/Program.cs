using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Songs
{
    
    class Program
    {
        static string GetDuration(int seconds)
        {
            int hours = seconds / (60 * 60);
            seconds -= hours * 60 * 60;
            int minutes = seconds / 60;
            seconds -= minutes * 60;
            
            return $"{hours}h {minutes}m {seconds}s";
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>(n); 
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] tokens = Console.ReadLine().Split(';').Select(x => x.Trim()).ToArray();
                    //if (tokens.Length < 3)
                    //{
                    //    continue;
                    //}
                    Song currSong = new Song(tokens[0], tokens[1], tokens[2]);
                    songs.Add(currSong);
                    Console.WriteLine("Song added.");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            int playListDuration = 0;
            songs.ForEach(x => playListDuration += x.GetDurationInSeconds());
            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {GetDuration(playListDuration)}");
            
        }
    }
}
