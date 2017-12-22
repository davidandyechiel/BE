using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class HoursInWeek : IEnumerable
    {
        private HoursInDay[] week;

        public HoursInWeek(HoursInDay[] _week)
        {
            this.week = new HoursInDay[6];
            this.Week = _week;
        }
        public HoursInWeek()
        {
            this.week = new HoursInDay[6];
        }

        public HoursInWeek


        public HoursInDay[] Week
        {
            get
            {
                return week;
            }

            set
            {
                for (int i = 0; i < 6; i++)
                {
                    week[i] = value[i];
                }        
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 6; i++)
            {
                yield return Week[i];
            }
        }

        public override string ToString()
        {
            string str = "";
            E_days day = E_days.Sunday;
            foreach (HoursInDay item in Week)
            {
                str += ((day++) + item.ToString() + "\n") ;
            }
            return str;
        }
    }
}
