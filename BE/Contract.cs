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
        private double wages;
        // private double wagesPerMonth;
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

        }

        public int ChildID
        {
            get
            {
                return childID;
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

        public double Wages
        {
            get
            {
                return wages;
            }

            set
            {
                wages = value;
            }
        }

        //public double WagesPerMonth
        //{
        //    get
        //    {
        //        return wagesPerMonth;
        //    }

        //    set
        //    {
        //        wagesPerMonth = value;
        //    }
        //}

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
        public Contract(int nannyId , int chilId)
        {
            this.nannysID = nannyId;
           this.childID = chilId;
        }

        public Contract(int nannysID, int childID, bool hadMeeting, bool isSigned, double wages, bool ishourly, DateTime startDate, DateTime endDate)
        {
            this.nannysID = nannysID;
            this.childID = childID;
            this.HadMeeting = hadMeeting;
            this.IsSigned = isSigned;
            this.Wages = wages;
            this.Ishourly = ishourly;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        public Contract(Nanny nanny, Mother mom, Child child, double wages, bool ishourly, DateTime startDate, DateTime endDate)
        {
            nannysID = nanny.Id;
            childID = child.Id;
            HadMeeting = hadMeeting;
            IsSigned = false;
            // TODO: make these properties depended
            Wages = wages; // maby make it depended
            Ishourly = ishourly; // meby mekr it depended
            StartDate = startDate; // maby make it depended
            EndDate = endDate; // maby make it depended
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
