using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    public class Mother
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
        private HoursInDay hoursTable;//table that stores the start and end time of each day of the week 
        #region Property
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
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

        public DateTime[,] HoursTable
        {
            get
            {
                return hoursTable;
            }

            set
            {
                hoursTable = value;
            }
        }
        #endregion
        #region Ctor
        public Mother() { }
        public Mother(int id, string lastName, string firstName, int homePhoneNum, int cellPhoneNum, string address, string addressNearHere, int hoursNeeded, int daysNeeded, bool[] needNanny, string notes, DateTime[,] hoursTable)
        {
            this.Id = id;
            LastName1 = lastName;
            FirstName1 = firstName;
            this.HomePhoneNum = homePhoneNum;
            this.CellPhoneNum = cellPhoneNum;
            this.Address = address;
            this.AddressNearHere = addressNearHere;
            this.HoursNeeded = hoursNeeded;
            this.DaysNeeded = daysNeeded;
            this.NeedNanny = needNanny;
            this.Notes = notes;
            this.HoursTable = hoursTable;
        }
        #endregion
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

    }
}
