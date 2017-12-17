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
         // need to add the hours of working
        
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
