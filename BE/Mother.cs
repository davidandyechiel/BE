using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BE
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class Mother : IComparable , INotifyPropertyChanged
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
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
        private DateTime[,] dthoursTable;//table that stores the start and end time of each day of the week



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

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Id"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HomePhoneNum"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CellPhoneNum"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Address"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AddressNearHere"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HoursNeeded"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DaysNeeded"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NeedNanny"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Notes"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("numOfKids"));
            }
        }
        public DateTime[,] DThoursTable
        {
            get
            {
                return dthoursTable;
            }

            set
            {
                 dthoursTable = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("dthoursTable"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Ctor
        public Mother()
        {
            DThoursTable.setDefaulteTable();
        }

        public Mother(int id, string lastName, string firstName, int homePhoneNum, int cellPhoneNum, string address, string addressNearHere, int hoursNeeded, int daysNeeded, bool[] needNanny, string notes, int numOfKids)
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
            
            needNanny = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                needNanny[i] = (dthoursTable[i,0] == dthoursTable[i,1]) ? false:true;
            }
            DThoursTable.setDefaulteTable();

        }


        public Mother(int id, string lastName, string firstName, int homePhoneNum, int cellPhoneNum, string address, string addressNearHere, string notes, DateTime[,] dthoursTable, int numOfKids)
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
            DThoursTable = DThoursTable.setDefaulteTable();
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
            DThoursTable = DThoursTable.setDefaulteTable();

        }

        public Mother(Mother mom)
        {
            this.id = mom.Id;
            this.lastName = mom.LastName;
            this.firstName = mom.FirstName;
            this.homePhoneNum = mom.HomePhoneNum;
            this.cellPhoneNum = mom.CellPhoneNum;
            this.address = mom.Address;
            this.addressNearHere = mom.AddressNearHere;
            this.notes = mom.Notes;
            this.dthoursTable = mom.DThoursTable;
            this.numOfKids = mom.NumOfKids;
            dthoursTable = new DateTime[6, 2];
            DThoursTable = DThoursTable.setDefaulteTable(mom.DThoursTable);
        }

        public Mother(int id)
        {
            this.id = id;
            DThoursTable = DThoursTable.setDefaulteTable();
        }


        #endregion







        public override string ToString()
        {
            return  LastName + " "  + FirstName + " ID: " + Id;
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
