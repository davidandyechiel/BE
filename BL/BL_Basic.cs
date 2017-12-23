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
                if ((((Contract)obj).(MyDal.getMotherDS().Find(x => x.Id == (MyDal.getChildDS().Find(y => y.Id == (((Contract)obj).ChildID)).MothersId)).NumOfKids))>2)
                {
                    if (((Contract)obj).Ishourly)
                        ((Contract)obj).WagesPerHour = (MyDal.getNannyDS().Find(x => x.Id == (((Contract)obj).NannysID)).HourRate) * (MyDal.getMotherDS().Find(x => x.Id == (MyDal.getChildDS().Find(y => y.Id == (((Contract)obj).ChildID)).MothersId)).HoursNeeded) * 4;
                }
                else
                    MyDal.Add(obj);
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

        public Idal getChildDS()
        {
            throw new NotImplementedException();
        }

        public Idal getContractDS()
        {
            throw new NotImplementedException();
        }

        public Idal getMotherDS()
        {
            throw new NotImplementedException();
        }

        public Idal getNannyDS()
        {
            throw new NotImplementedException();
        }

       
    }
}
