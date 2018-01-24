﻿using System;
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

        public static IBL Instance
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
                if (getAge(((Nanny)obj).BirthDate) < 18)
                    throw new Exception("Too young to be a nanny");
            
            }
            if (obj is Child)
            {
               if (getAge(((Child)obj).Birthday) <  0.03)
                    throw new Exception("Child is too young to leave his/her mother");
              
            }
           
            if (obj is Contract)
                if ((findMotherFromContract((Contract) obj).NumOfKids)>2)
                {
                    if (((Contract)obj).Ishourly)
                        ((Contract)obj).Wages = ((MyDal.NannyDS.Find(x => x.Id == (((Contract)obj).NannysID)).HourRate) 
                            * (findMotherFromContract((Contract)obj).HoursNeeded) * 4)*0.02* (findMotherFromContract((Contract)obj).NumOfKids);//rate per hour *hours per week * 4 *0.02 *num of kids
                    else
                        ((Contract)obj).Wages = ((MyDal.NannyDS.Find(x => x.Id == (((Contract)obj).NannysID)).MonthlyRate)
                            *0.02 * (findMotherFromContract((Contract)obj).NumOfKids));//rate per month * 0.02*num of kids
                }
            MyDal.Add(obj);

        }

        //calculate the age from birthdate untill today FORMAT: Y Y . 0 M M
        private double getAge(DateTime birthdate)
        {
            double now = DateTime.Now.Year + (((double)DateTime.Now.Month)/100);
            double dayOfBirth = birthdate.Year + ((12-(double)(birthdate.Month)) / 100);
            return (now - dayOfBirth);
        }

        private Mother findMotherFromContract(Contract contract)
        {
            return MyDal.MotherDS.Find(x => x.Id == (MyDal.ChildDS.Find(y => y.Id == (contract.ChildID)).MothersId));
        }

        
        public void Remove( object obj)
        {
            MyDal.Remove(obj);
        }

        public void Update( object obj)
        {
            if (obj is Nanny)
            {
                if (getAge(((Nanny)obj).BirthDate) < 18)
                    throw new Exception("Too young to be a nanny");
            }
            if (obj is Child)
            {
                if (getAge(((Child)obj).Birthday) < 0.03)
                    throw new Exception("Child is too young to leave his/her mother");
                
            }
            MyDal.Update(obj);
        }

        public List<Child> getChildDS()
        {
            return MyDal.ChildDS;
        }

        public List<Contract> getContractDS()
        {
            return MyDal.ContractDS;
        }

        public List<Mother> getMotherDS()
        {
            return MyDal.MotherDS;
        }

        public List<Nanny> getNannyDS()
        {
            return MyDal.NannyDS;
        }

        public  List<Nanny> nannysThatCanWorkForMe(Mother m)
        {
            DateTime[,] momhours = m.DThoursTable;
            List<Nanny> list = new List<Nanny>();
            foreach (Nanny nanny in getNannyDS())
            {
                
                    if ((nanny.DThoursTable.CompareTo(momhours)))
                        //   if the start hour of the nanny is earlier than the desired mothers strt time and the end hour of the nanny is later than the desired mothers end time
                        list.Add(nanny);
               
                           
            }
            return list;
        }
      /*  public List<Nanny> nannysThatCanWorkForMePlus(Mother m)
        {

            List<Nanny> list = nannysThatCanWorkForMe(m);
            if (list.Count < 5)
                if (getNannyDS().Count < 5)
                    return list;

            list.Concat(list.Compromise(5 - list.Count);

            
        }*/

        public Contract FindContract(Predicate<Contract> p)
        {
            return MyDal.ContractDS.Find(p);
        }

       public  Child FindChild(Predicate<Child> p)
        {
            return MyDal.ChildDS.Find(p);
        }

       public Mother FindMother(Predicate<Mother> p)
        {
            return MyDal.MotherDS.Find(p);
        }
        public Nanny FindNanny(Predicate<Nanny> p)
        {
            return MyDal.NannyDS.Find(p);
        }

        public IBL myInstance()
        { return Instance; }

        

        public bool Exists(object obj)
        {
            return MyDal.Exists(obj);
        }

        

        public DateTime[][] setHoursIntDT(params int[] times)
        {
            DateTime[][] hours = new DateTime[6][];
            for (int i = 0; i < times.Length; i++)
            {
                hours[i] = new DateTime[2];
                hours[i][0] = DoubleToDateTime(times[i]);
                hours[i][1] = DoubleToDateTime(times[i + 1]);
            }
            return hours;
        }

        public DateTime[][] setHoursIntDT(params double[] times)
        {
            DateTime[][] hours = new DateTime[6][];
            for (int i = 0; i < 6; i++)
            {
                hours[i] = new DateTime[2];
                hours[i][0] = DoubleToDateTime(times[i]);
                hours[i][1] = DoubleToDateTime(times[i + 1]);
            }
            return hours;
        }
    }
}
