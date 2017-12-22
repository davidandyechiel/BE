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
    class HoursInDay
    {
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
         #endregion
        #region Ctrs
        public HoursInDay(ClockTime start, ClockTime end)
        {
            this.Start = start;
            this.End = end;
        }
        #endregion

        public void setHoursInDay(ClockTime start, ClockTime end)
        {
            Start = start;
            End = End;
        }
        public override string ToString()
        {
            return "start: " +  Start + " end:" + End;
        }

    }
}
