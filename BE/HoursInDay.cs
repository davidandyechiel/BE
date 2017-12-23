using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    ///  this class Has two ClockTime that show the start time and the end time in a day.
    /// </summary>
    public class HoursInDay
    {
        private E_days day;
        private ClockTime start;
        private ClockTime end;
        #region Property
        public ClockTime Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }

        public ClockTime End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }

        public E_days Day
        {
            get
            {
                return day;
            }

            set
            {
                day = value;
            }
        }
        #endregion
        #region Ctrs
        public HoursInDay(E_days day, ClockTime start, ClockTime end)
        {
            Day = day;
            this.Start = start;
            this.End = end;
        }
        #endregion

      
        public override string ToString()
        {
            return Day + ": start - " +  Start + " end - " + End;
        }

    }
}
