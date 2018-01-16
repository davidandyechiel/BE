using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    public class Mother : IComparable
    {
        private int id;
        private string lastName;
        private string firstName;
        private int homePhoneNum;
        private int cellPhoneNum;
        private string address;
        private string addressNearHere;//
        private int hoursNeeded;//how many hours per week needed
        private int daysNeeded;//how many days per week needed 
        private bool[] needNanny;//days of the week mother needs a nanny
        private string notes;
        private int numOfKids; // number of the kids that need a nanny
        private DateTime[][] dthoursTable;//table that stores the start and end time of each day of the week


        #region Property
        public int Id
        {
            get
            {
                return id;
            }

        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public int HomePhoneNum
        {
            get
            {
                return homePhoneNum;
            }

            set
            {
                homePhoneNum = value;
            }
        }

        public int CellPhoneNum
        {
            get
            {
                return cellPhoneNum;
            }

            set
            {
                cellPhoneNum = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string AddressNearHere
        {
            get
            {
                return addressNearHere;
            }

            set
            {
                addressNearHere = value;
            }
        }

        public int HoursNeeded
        {
            get
            {
                return hoursNeeded;
            }

            set
            {
                hoursNeeded = value;
            }
        }

        public int DaysNeeded
        {
            get
            {
                return daysNeeded;
            }

            set
            {
                daysNeeded = value;
            }
        }

        public bool[] NeedNanny
        {
            get
            {
                return needNanny;
            }

            set
            {
                needNanny = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }



        public int NumOfKids
        {
            get
            {
                return numOfKids;
            }

            set
            {
                numOfKids = value;
            }
        }
        public DateTime[][] DThoursTable
        {
            get
            {
                return dthoursTable;
            }

            set
            {
                 dthoursTable = value;
            }
        }

        #endregion
        #region Ctor
        public Mother()
        {

        }

        public Mother(int id, string lastName, string firstName, int homePhoneNum, int cellPhoneNum, string address, string addressNearHere, int hoursNeeded, int daysNeeded, bool[] needNanny, string notes, int numOfKids, DateTime[][] dthoursTable)
        {
            
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.homePhoneNum = homePhoneNum;
            this.cellPhoneNum = cellPhoneNum;
            this.address = address;
            this.addressNearHere = addressNearHere;
            this.hoursNeeded = hoursNeeded;
            this.daysNeeded = daysNeeded;
            this.needNanny = needNanny;
            this.notes = notes;
            this.numOfKids = numOfKids;
            this.dthoursTable = dthoursTable;
            needNanny = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                needNanny[i] = (dthoursTable[i][0] == dthoursTable[i][1]) ? false:true;
            }

        }


        public Mother(int id, string lastName, string firstName, int homePhoneNum, int cellPhoneNum, string address, string addressNearHere, string notes, DateTime[][] dthoursTable, int numOfKids)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.homePhoneNum = homePhoneNum;
            this.cellPhoneNum = cellPhoneNum;
            this.address = address;
            this.addressNearHere = addressNearHere;
            this.notes = notes;
            this.dthoursTable = dthoursTable;
            this.numOfKids = numOfKids;
        }

        public Mother(int id, string lastName, string firstName, int homePhoneNum, int cellPhoneNum, string address, string addressNearHere, int hoursNeeded, int daysNeeded, string notes, int numOfKids)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.homePhoneNum = homePhoneNum;
            this.cellPhoneNum = cellPhoneNum;
            this.address = address;
            this.addressNearHere = addressNearHere;
            this.hoursNeeded = hoursNeeded;
            this.daysNeeded = daysNeeded;
            this.notes = notes;
            this.numOfKids = numOfKids;

        }


        #endregion

        //private static DateTime convertToTime(this double d)
        //{
        //    IFormatProvider format  = ""
        //    string str = Convert.ToString(d,)
        //    return Convert.ToDateTime(d); 
        //}
        //static public DateTime[][] setHours(params double[] times)
        //{
        //    DateTime[][] hours = new DateTime[6][];
        //    for (int i = 0; i < times.Length; i += 2)
        //    {
        //        hours[i / 2][0] = times[i];
        //        hours[i / 2][1] = times[i + 1];
        //    }
        //    return hours;
        //}

        public override string ToString()
        {
            return "Mother: " + LastName + FirstName + " ID: " + Id;
        }

        public int CompareTo(object obj)
        {
            return id.CompareTo(((Mother)obj).Id);
        }

        public override bool Equals(object obj)
        {
            return (id.CompareTo(((Mother)obj).Id) == 0);
        }

    }
}
