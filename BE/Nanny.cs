using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BE
{



#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class Nanny : IComparable, INotifyPropertyChanged
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private int id;
        private string lastName;
        private string firstName;
        private DateTime birthDate; 
        private int phoneNum;
        private bool elevator; // if ther is elevator in the bulding
        private string adress;
        private int floor;
        private int experince; // years of experience
        private int maxCapacity; // max capacity of children
        private double minAge; // min age of the childen
        private double maxAge; // max age of childern
        private bool perHour; // if the nanny is also wokring hourly payment
        private double hourRate; // the dayly Rate of the nanny
        private double monthlyRate; // the monthly Rate of the nanny
        private string recommendations;
        private bool dependedDaysOff; // if the nanny's Day-Offs depend on the goverment
        private bool[] daysOfWork; // which days is the nanny work
     //   private HoursInWeek hoursTable;//table that stores the start and end time of each day of the week
        private DateTime[][] dthoursTable;//table that stores the start and end time of each day of the week
        private int difference; // 

        public event PropertyChangedEventHandler PropertyChanged;


        #region Property
        public int Id
        {
            get
            {
                return id;
            }
            set { id = value;

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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BirthDate"));
            }
        }

        public int PhoneNum
        {
            get
            {
                return phoneNum;
            }

            set
            {
                phoneNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhoneNum"));
            }
        }

        public bool Elevator
        {
            get
            {
                return elevator;
            }

            set
            {
                elevator = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Elevator"));
            }
        }

        public string Adress
        {
            get
            {
                return adress;
            }

            set
            {
                adress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Adress"));
            }
        }

        public int Floor
        {
            get
            {
                return floor;
            }

            set
            {
                floor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Floor"));
            }
        }

        public int Experince
        {
            get
            {
                return experince;
            }

            set
            {
                experince = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Experince"));
            }
        }

        public int MaxCapacity
        {
            get
            {
                return maxCapacity;
            }

            set
            {
                maxCapacity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxCapacity"));
            }
        }

        public double MinAge
        {
            get
            {
                return minAge;
            }

            set
            {
                minAge = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinAge"));
            }
        }

        public double MaxAge
        {
            get
            {
                return maxAge;
            }

            set
            {
                maxAge = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxAge"));
            }
        }

        public bool PerHour
        {
            get
            {
                return perHour;
            }

            set
            {
                perHour = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PerHour"));
            }
        }

        public double HourRate
        {
            get
            {
                return hourRate;
            }

            set
            {
                hourRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HourRate"));
            }
        }


        public string Recommendations
        {
            get
            {
                return recommendations;
            }

            set
            {
                recommendations = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Recommendations"));
            }
        }

        public bool DependedDaysOff
        {
            get
            {
                return dependedDaysOff;
            }

            set
            {
                dependedDaysOff = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DependedDaysOff"));
            }
        }

        public bool[] DaysOfWork
        {
            get
            {
                return daysOfWork;
            }

            set
            {
                daysOfWork = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DaysOfWork"));
            }
        }

   /*     public HoursInWeek HoursTable 
        {
            get
            {
                return hoursTable;
            }

            set
            {
                hoursTable = value;
            }
        }*/
        public DateTime[][] DThoursTable
        {
            get
            {
                return dthoursTable;
            }

            set
            {
                dthoursTable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DThoursTable"));
            }
        }

        public int Difference
        {
            get
            {
                return difference;
            }

            set
            {
                difference = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Difference"));
            }
        }

        public double MonthlyRate
        {
            get
            {
                return monthlyRate;
            }

            set
            {
                monthlyRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MonthlyRate"));
            }
        }

        #endregion
        #region Ctor

        public Nanny() { }

        public Nanny(int id)
        {
            this.id = id;
        }

       /* public Nanny(int difference)
        {
            this.Difference = difference;
        }*/

        public Nanny(int id, string lastName, string firstName, DateTime birthDate/*, int phoneNum, bool elevator, string adress, int floor, int experince, int maxCapacity, double minAge, double maxAge, bool perHour, double hourRate, double monthlyRate, string recommendations, bool dependedDaysOff, bool[] daysOfWork, DateTime[][] dthoursTable, int difference*/)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.birthDate = birthDate;
            //this.phoneNum = phoneNum;
            //this.elevator = elevator;
            //this.adress = adress;
            //this.floor = floor;
            //this.experince = experince;
            //this.maxCapacity = maxCapacity;
            //this.minAge = minAge;
            //this.maxAge = maxAge;
            //this.perHour = perHour;
            //this.hourRate = hourRate;
            //this.monthlyRate = monthlyRate;
            //this.recommendations = recommendations;
            //this.dependedDaysOff = dependedDaysOff;
            //this.daysOfWork = daysOfWork;
            //this.dthoursTable = dthoursTable;
            //this.difference = difference;
        }

        public Nanny(int id, string lastName, string firstName, DateTime birthDate, int phoneNum, bool elevator, string adress, int floor, int experince, int maxCapacity, double minAge, double maxAge, bool perHour, double hourRate, double monthlyRate, string recommendations, bool dependedDaysOff, bool[] daysOfWork, DateTime[][] dthoursTable)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.birthDate = birthDate;
            this.phoneNum = phoneNum;
            this.elevator = elevator;
            this.adress = adress;
            this.floor = floor;
            this.experince = experince;
            this.maxCapacity = maxCapacity;
            this.minAge = minAge;
            this.maxAge = maxAge;
            this.perHour = perHour;
            this.hourRate = hourRate;
            this.monthlyRate = monthlyRate;
            this.recommendations = recommendations;
            this.dependedDaysOff = dependedDaysOff;
            this.daysOfWork = daysOfWork;
            this.dthoursTable = dthoursTable;
        }

        public Nanny(Nanny nanny)
        {
            this.id = nanny.id;
            this.lastName = nanny.lastName;
            this.firstName = nanny.firstName;
            this.birthDate = nanny.birthDate;
            this.phoneNum = nanny.phoneNum;
            this.elevator = nanny.elevator;
            this.adress = nanny.adress;
            this.floor = nanny.floor;
            this.experince = nanny.experince;
            this.maxCapacity = nanny.maxCapacity;
            this.minAge = nanny.minAge;
            this.maxAge = nanny.maxAge;
            this.perHour = nanny.perHour;
            this.hourRate = nanny.hourRate;
            this.monthlyRate = nanny.monthlyRate;
            this.recommendations = nanny.recommendations;
            this.dependedDaysOff = nanny.dependedDaysOff;
            this.daysOfWork = nanny.daysOfWork;
            this.dthoursTable = nanny.dthoursTable;
            this.difference = nanny.difference;
        }



        #endregion

        public override string ToString()
        {
            return "Nanny: "  + LastName + FirstName + " ID: "+ Id;
        }
        public int CompareTo(object obj)
        {
            return id.CompareTo(((Nanny)obj).Id);
        }

        public override bool Equals(object obj)
        {
            return (id.CompareTo(((Nanny)obj).Id) == 0);
        }
    }
}
