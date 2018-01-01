using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DS;
using BE;



namespace BL
{
   public sealed partial class BL_Basic : IBL
    {
        private static Idal MyDal;

        #region Singleton
        private static readonly BL_Basic instance = new BL_Basic();

        public static BL_Basic Instance
        {
            get { return instance; }
        }
        #endregion 

        #region Constructor
        private BL_Basic() { }
        static BL_Basic()
        {
               MyDal = Dal_imp.Instance;
        }
        #endregion


        public void Add(object obj)
        {
            if (obj is Nanny)
            {
                if (((Nanny)obj).BirthDate.AddYears(18) < DateTime.Now)
                    throw new Exception("Too young to be a nanny");
                MyDal.Add(obj);
            }
            if (obj is Child)
            {
           //     if (((Child)obj).Birthday.AddMonths(3) < DateTime.Now)
            //        throw new Exception("Child is too young to leave his/her mother");
                MyDal.Add(obj);
            }
            if (obj is Contract)
                if ((findMotherFromContract((Contract) obj).NumOfKids)>2)
                {
                    if (((Contract)obj).Ishourly)
                        ((Contract)obj).Wages = ((MyDal.getNannyDS().Find(x => x.Id == (((Contract)obj).NannysID)).HourRate) 
                            * (findMotherFromContract((Contract)obj).HoursNeeded) * 4)*0.02* (findMotherFromContract((Contract)obj).NumOfKids);//rate per hour *hours per week * 4 *0.02 *num of kids
                    else
                        ((Contract)obj).Wages = ((MyDal.getNannyDS().Find(x => x.Id == (((Contract)obj).NannysID)).MonthlyRate)
                            *0.02 * (findMotherFromContract((Contract)obj).NumOfKids));//rate per month * 0.02*num of kids
                }

        }


        private Mother findMotherFromContract(Contract contract)
        {
            return MyDal.getMotherDS().Find(x => x.Id == (MyDal.getChildDS().Find(y => y.Id == (contract.ChildID)).MothersId));
        }

        
        public void Remove( object obj)
        {
            MyDal.Remove(obj);
        }

        public void Update( object obj)
        {
            if (obj is Nanny)
            {
                if (((Nanny)obj).BirthDate.AddYears(18) < DateTime.Now)
                    throw new Exception("Too young to be a nanny");
                MyDal.Update(obj);
            }
            if (obj is Child)
            {
                if (((Child)obj).Birthday.AddMonths(3) < DateTime.Now)
                    throw new Exception("Child is too young to leave his/her mother");
                MyDal.Update(obj);
            }
        }

        public List<Child> getChildDS()
        {
            return MyDal.getChildDS();
        }

        public List<Contract> getContractDS()
        {
            return MyDal.getContractDS();
        }

        public List<Mother> getMotherDS()
        {
            return MyDal.getMotherDS();
        }

        public List<Nanny> getNannyDS()
        {
            return MyDal.getNannyDS();
        }

        public List<Nanny> nannysThatCanWorkForMe(Mother m)
        {
            bool flag = true;
            DateTime[][] momhours = m.DThoursTable;
            List<Nanny> list = new List<Nanny>();
            foreach (Nanny nanny in getNannyDS())
            {
                for (int i = 0; i <= 6; i++)
                {
                    if (!(nanny.DThoursTable[0][i].CompareTo(momhours[0][i]) <= 0 && nanny.DThoursTable[1][i].CompareTo(momhours[1][i]) >= 0))
                        // !  if the start hour of the nanny is earlier than the desired mothers strt time and the end hour of the nanny is later than the desired mothers end time
                        flag = false;
                }
                if (flag == true)
                    list.Add(nanny);          
            }
            return list;
        }
        public List<Nanny> nannysThatCanWorkForMePlus(Mother m)
        {
            bool flag = true;
            DateTime[][] momhours = m.DThoursTable;
            List<Nanny> list = new List<Nanny>();
            List<Nanny> listPro = new List<Nanny>();
            foreach (Nanny nanny in getNannyDS())
            {
                 nanny.Difference = 0;
                for (int i = 0; i <= 6; i++)
                {
                    if (!(nanny.DThoursTable[0][i].CompareTo(momhours[0][i]) <= 0 && nanny.DThoursTable[1][i].CompareTo(momhours[1][i]) >= 0))
                    {//   if the start hour of the nanny is earlier than the desired mothers strt time and the end hour of the nanny is later than the desired mothers end time
                        flag = false;
                        nanny.Difference += (nanny.DThoursTable[1][i].Hour * 60 + nanny.DThoursTable[1][i].Minute) - (m.DThoursTable[1][i].Hour * 60 + m.DThoursTable[1][i].Minute);
                        listPro.Add(nanny);
                    }
                }
                if (flag == true)
                    list.Add(nanny);
            }
            if (list == null)
            {
                listPro.Sort(delegate (Nanny x, Nanny y)
                {
                    if (x == null && y == null) return 0;
                    else if (x == null) return -1;
                    else if (y == null) return 1;
                    else return x.Difference.CompareTo(y.Difference);
                });
                return listPro;
            }
            return list;
        }

        public E_type toE_type(object o)
        {

            return enumVal;
        }

    }
}
