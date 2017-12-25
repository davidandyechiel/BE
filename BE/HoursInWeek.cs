using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HoursInWeek : IEnumerable
    {
        const int MAX_DAYS_IN_WEEK = 6;
        private HoursInDay[] weekHours;

        #region Ctrs            
        public HoursInWeek(params HoursInDay[] _weekArgs)
        {
            weekHours = new HoursInDay[MAX_DAYS_IN_WEEK];
            weekHours = _weekArgs;
        }

        public HoursInWeek()
        {
            this.weekHours = new HoursInDay[MAX_DAYS_IN_WEEK];
        }
        #endregion
        #region Property

        public HoursInDay[] WeekHours
        {
            get
            {
                return weekHours;
            }

            set
            {
                foreach (HoursInDay item in value)
                {
                    weekHours[(int)item.Day].Day = item.Day;
                    weekHours[(int)item.Day].Start = item.Start;
                    weekHours[(int)item.Day].End = item.End;
                }
            }
        }
        #endregion

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 6; i++)
            {
                yield return weekHours[i];
            }
        }


        public override bool Equals(object obj)
        {
            bool equal = true;
            int i = 0;
            foreach (HoursInDay first in WeekHours)
            {
                if (!(first == ((HoursInWeek)obj).WeekHours[i++]))
                {
                    equal = false;
                    break;
                }
            }
            return equal;
        }

        public override string ToString()
        {
            string str = "";
            foreach (HoursInDay item in weekHours)
            {
                str += (item.ToString() + "\n");
            }
            return str;
        }

       /* public int CompareTo(object obj)
        {
            HoursInDay second = ((HoursInWeek)obj).WeekHours[0];
            for (int i = 0; i < MAX_DAYS_IN_WEEK; i++)
            { if( weekHours[i].CompareTo(second)

            }
        }*/
    }
}
