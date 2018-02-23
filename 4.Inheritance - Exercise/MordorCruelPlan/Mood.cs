using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordorCruelPlan
{
    public abstract class Mood
    {
        public abstract string MoodType { get; }
    }

    public class Angry : Mood
    {
        private string _moodType = "Angry";

        public override string MoodType
        {
            get { return _moodType; }
        }
    }
    public class Sad : Mood
    {
        private string _moodType = "Sad";

        public override string MoodType
        {
            get { return _moodType; }
        }
    }
    public class Happy : Mood
    {
        private string _moodType = "Happy";

        public override string MoodType
        {
            get { return _moodType; }
        }
    }
    public class JavaScript : Mood
    {
        private string _moodType = "JavaScript";

        public override string MoodType
        {
            get { return _moodType; }
        }
    }
    public static class MoodFactory
    {
        public static string GetGandalfMood(int points)
        {
            if(points < -5) return new Angry().MoodType;
            else if(points <= 0) return new Sad().MoodType;
            else if(points <= 15) return new Happy().MoodType;
            else return new JavaScript().MoodType;
        }
    }
}
