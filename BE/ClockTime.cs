using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// this class is keeping the time in format HH:MM
    /// </summary>
    class ClockTime : IComparable
    {
        int hours;
        int minutes;
        #region Ctrs
        public ClockTime() { }
        public ClockTime(ClockTime copyCtr)
        {
            this.Hours = copyCtr.Hours;
            this.Minutes = copyCtr.Minutes;
        }
        public ClockTime(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }
        public ClockTime(string time)
        {
            string[] timeSplit = time.Split(':');
            if (timeSplit.Length != 2)
                throw new Exception("Illeagal deffenition, please enter time like HH:MM");
            if ((int.Parse(timeSplit[0]) > 23) || (int.Parse(timeSplit[0]) < 0))
                throw new Exception("Hour is Illegal");
            if ((int.Parse(timeSplit[1]) > 23) || (int.Parse(timeSplit[1]) < 0))
                throw new Exception("Minute is Illegal");
            this.Hours = hours;
            this.Minutes = minutes;
        }
        #endregion
        #region Property
        public int Hours
        {
            get
            {
                return hours;
            }

            set
            {
                hours = value;
            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }

            set
            {
                minutes = value;
            }
        }

      
        #endregion
        public int CompareTo(object obj)
        {
            if (Hours == ((ClockTime)obj).Hours)
                return minutes.CompareTo(((ClockTime)obj).Minutes);
            return hours.CompareTo(((ClockTime)obj).Hours);
        }

    }
}
