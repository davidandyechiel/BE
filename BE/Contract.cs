using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract : IComparable
    {
        public static int ContractNumCounter = 10000000;

        int contractNum;
        private int nannysID;
        private int childID;
        bool hadMeeting;
        bool isSigned;
        private double wagesPerHour;
        private double wagesPerMonth;
        private bool ishourly;//are the wages hourly or monthly
        private DateTime startDate;
        private DateTime endDate;
        #region Property
        public int ContractNum
        {
            get
            {
                return contractNum;
            }
            set
            {
                contractNum = value;
            }

        }

        public int NannysID
        {
            get
            {
                return nannysID;
            }

            set
            {
                nannysID = value;
            }
        }

        public int ChildID
        {
            get
            {
                return childID;
            }

            set
            {
                childID = value;
            }
        }

        public bool HadMeeting
        {
            get
            {
                return hadMeeting;
            }

            set
            {
                hadMeeting = value;
            }
        }

        public bool IsSigned
        {
            get
            {
                return isSigned;
            }

            set
            {
                isSigned = value;
            }
        }

        public double WagesPerHour
        {
            get
            {
                return wagesPerHour;
            }

            set
            {
                wagesPerHour = value;
            }
        }

        public double WagesPerMonth
        {
            get
            {
                return wagesPerMonth;
            }

            set
            {
                wagesPerMonth = value;
            }
        }

        public bool Ishourly
        {
            get
            {
                return ishourly;
            }

            set
            {
                ishourly = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }
        #endregion
        #region Ctors
        public Contract() { }
        public Contract(int contractNum, int nannysID, int childID, bool hadMeeting, bool isSigned, double wagesPerHour, double wagesPerMonth, bool ishourly, DateTime startDate, DateTime endDate)
        {
            
            this.NannysID = nannysID;
            this.ChildID = childID;
            this.HadMeeting = hadMeeting;
            this.IsSigned = isSigned;
            this.WagesPerHour = wagesPerHour;
            this.WagesPerMonth = wagesPerMonth;
            this.Ishourly = ishourly;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }






        #endregion

        public override string ToString()  
        {
            return base.ToString();
        }
        public int CompareTo(object obj)
        {
            return contractNum.CompareTo(((Contract)obj).ContractNum);
        }

        public override bool Equals(object obj)
        {
            return (NannysID == (((Contract)obj).NannysID) && ChildID == (((Contract)obj).ChildID));
        }


    }
}
