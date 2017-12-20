using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace DS
{
    class DataSource
    {
        protected static List<Nanny> nannyList = null;
        protected static List<Mother> motherList = null;
        protected static List<Child> childList = null;
        protected static List<Contract> contractList = null;

        public static List<Nanny> getNannyList()
        {
            if (nannyList == null)
                nannyList = new List<Nanny>();
            return nannyList;
        }
        public static List<Mother> getMotherList()
        {
            if (motherList == null)
                motherList = new List<Mother>();
            return motherList;
        }
        public static List<Child> getChildList()
        {
            if (childList == null)
                childList = new List<Child>();
            return childList;
        }
        public static List<Contract> getContractList()
        {
            if (contractList == null)
                contractList = new List<Contract>();
            return contractList;
        }


    }
}
