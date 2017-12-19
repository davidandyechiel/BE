using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    enum E_days { Sunday =1, Monday, Tuesday, Wednesday ,Friday, Saturday};

    public class Nanny
    {
        private int id;
        private string LastName;
        private string FirstName;
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
        private double hourRate; // the hourly Rate of the nanny
        private double monthlyRate; // the monthly Rate of the nanny
        private string recommendations;
        private bool dependedDaysOff; // if the nanny's Day-Offs depend on the goverment
        private bool[] daysOfWork; // which days is the nanny work
        private DateTime[,] hoursTable;//table that stores the start and end time of each day of the week
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

        public string LastName1
        {
            get
            {
                return LastName;
            }

            set
            {
                LastName = value;
            }
        }

        public string FirstName1
        {
            get
            {
                return FirstName;
            }

            set
            {
                FirstName = value;
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

        public double MonthlyRate
        {
            get
            {
                return monthlyRate;
            }

            set
            {
                monthlyRate = value;
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

        public Nanny() { }
        public Nanny(int id, string lastName, string firstName, DateTime birthDate, int phoneNum, bool elevator, string adress, int floor, int experince, int maxCapacity, double minAge, double maxAge, bool perHour, double hourRate, double monthlyRate, string recommendations, bool dependedDaysOff, bool[] daysOfWork, DateTime[,] hoursTable)
        {
            this.Id = id;
            LastName1 = lastName;
            FirstName1 = firstName;
            this.BirthDate = birthDate;
            this.PhoneNum = phoneNum;
            this.Elevator = elevator;
            this.Adress = adress;
            this.Floor = floor;
            this.Experince = experince;
            this.MaxCapacity = maxCapacity;
            this.MinAge = minAge;
            this.MaxAge = maxAge;
            this.PerHour = perHour;
            this.HourRate = hourRate;
            this.MonthlyRate = monthlyRate;
            this.Recommendations = recommendations;
            this.DependedDaysOff = dependedDaysOff;
            this.DaysOfWork = daysOfWork;
            this.HoursTable = hoursTable;
        }
        #endregion

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
