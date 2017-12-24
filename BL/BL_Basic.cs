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
                if (((Child)obj).Birthday.AddMonths(3) < DateTime.Now)
                    throw new Exception("Child is too young to leave his/her mother");
                MyDal.Add(obj);
            }
            if (obj is Contract)
                if ((findMotherFromContract((Contract) obj).NumOfKids)>2)
                {
                    if (((Contract)obj).Ishourly)
                        ((Contract)obj).WagesPerHour = ((MyDal.getNannyDS().Find(x => x.Id == (((Contract)obj).NannysID)).HourRate) 
                            * (findMotherFromContract((Contract)obj).HoursNeeded) * 4)*0.02* (findMotherFromContract((Contract)obj).NumOfKids);//rate per hour *hours per week * 4 *0.02 *num of kids
                    else
                        ((Contract)obj).WagesPerHour = ((MyDal.getNannyDS().Find(x => x.Id == (((Contract)obj).NannysID)).MonthlyRate)
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

        

    }
}
