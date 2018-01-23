using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BE
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class Contract : IComparable, INotifyPropertyChanged
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("contractNum"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NannysID"));

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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ChildID"));

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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HadMeeting"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSigned"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Wages"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Ishourly"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("StartDate"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("EndDate"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
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
            return ContractNum.ToString();
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
