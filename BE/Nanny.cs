using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    


    public class Nanny : IComparable
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
        private int difference;


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

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
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
            }
        }

        #endregion
        #region Ctor

        public Nanny() { }

        public Nanny(int difference)
        {
            this.Difference = difference;
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
