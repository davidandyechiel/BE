using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Contract
    {
        static int ContractNum = 10000000;
        private int nannysID;
        private int childID;
        bool hadMeeting;
        bool isSigned;
        private double wagesPerHour;
        private double wagesPerMonth;
        private bool ishourly;//are the wages hourly of monthly
        private DateTime startDate;
        private DateTime endDate;
        public override string ToString()
        {
            return base.ToString();
        }


    }
}
