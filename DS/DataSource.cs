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
        

        #region singltone
        private static readonly DataSource instance = new DataSource();
        public static DataSource Instance
        {
            get { return instance; }
        }
        #endregion

        public  List<Nanny> getNannyDS()
        {
            if (nannyList == null)
                nannyList = new List<Nanny>();
            return nannyList;
        }
        public  List<Mother> getMotherDS()
        {
            if (motherList == null)
                motherList = new List<Mother>();
            return motherList;
        }
        public List<Child> getChildDS()
        {
            if (childList == null)
                childList = new List<Child>();
            return childList;
        }
        public  List<Contract> getContractDS()
        {
            if (contractList == null)
                contractList = new List<Contract>();
            return contractList;
        }
     
    }
}
