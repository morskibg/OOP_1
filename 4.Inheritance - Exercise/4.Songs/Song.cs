using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _4.Songs
{
    public class Song
    {
        private const int MinArtistNameLen = 3;
        private const int MaxArtistNameLen = 20;
        private const int MinSongNameLen = 3;
        private const int MaxSongNameLen = 30;
        private const int MaxMinutesDuratuoin = 14;
        private const int MinDuration = 0;
        private const int MaxSecondsDuration = 59;

        private string artistName;
        private string songName;
        private string duration;
        private int minutes;
        private int seconds;

        protected string ArtistName //•	Artist name should be between 3 and 20 symbols. 
        {
            get => artistName;
            set
            {
                if (value.Length > MaxArtistNameLen || value.Length < MinArtistNameLen)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidArtistNameException);
                }
                artistName = value;
            }
        }

        protected string SongName //•	Song name should be between 3 and 30 symbols. 
        {
            get => songName;
            set
            {
                if (value.Length > MaxSongNameLen || value.Length < MinSongNameLen)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongNameException);
                }
                songName = value;
            }
        }

        protected string Duration //•	Song length should be between 0 second and 14 minutes and 59 seconds.
        {

            get => duration;
            set
            {
                int tryParseMin = 0;
                int tryParseSec = 0;
                string[] tokens = value.Split(':').Select(x => x.Trim()).ToArray();
                if (tokens.Length < 2)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongLengthException);
                }
                if (!int.TryParse(tokens[0], out tryParseMin) || !int.TryParse(tokens[1], out tryParseSec))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongLengthException);
                }
                else
                {
                    this.minutes = tryParseMin;
                    this.seconds = tryParseSec;
                }
                if (this.minutes > MaxMinutesDuratuoin || this.minutes < MinDuration)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongMinutesException);
                }
                if (this.seconds > MaxSecondsDuration || this.seconds < MinDuration)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongSecondsException);
                }
                duration = value;
            }
        }

        public Song(string artistName, string songName, string duration)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Duration = duration;
        }

        public int GetDurationInSeconds()
        {
            return this.minutes * 60 + this.seconds;
        }
    }
}
