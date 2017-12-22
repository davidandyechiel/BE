using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    enum E_days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Sabbath };

   

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
        private double hourRate; // the hourly Rate of the nanny
        private double monthlyRate; // the monthly Rate of the nanny
        private string recommendations;
        private bool dependedDaysOff; // if the nanny's Day-Offs depend on the goverment
        private bool[] daysOfWork; // which days is the nanny work
        private HoursInDay[] hoursTable;//table that stores the start and end time of each day of the week

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
                if (PerHour)
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

        internal HoursInDay[] HoursTable // ??? i dont know why it works only in intenal ??? 
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
       

        #endregion

        public override string ToString()
        {
            throw new System.NotImplementedException();
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
