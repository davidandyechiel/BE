using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    class Mother
    {
        private int id;
        private string LastName;
        private string FirstName;
        private int homePhoneNum;
        private int cellPhoneNum;
        private string address;
        private string addressNearHere;//
        private int hoursNeeded;//how many hours per week needed
        private int daysNeeded;//how many days per week needed 
        private bool[] needNanny;//days of the week mother needs a nanny
        private string notes;
        private DateTime[,] hoursTable;//table that stores the start and end time of each day of the week 


        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

    }
}
