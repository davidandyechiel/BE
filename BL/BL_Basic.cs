using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DS;

namespace BL
{
   public sealed class BL_Basic : IBL
    {
        #region Singleton
        private static readonly BL_Basic instance = new BL_Basic();

        public static BL_Basic Instance
        {
            get { return instance; }
        }
        #endregion

        private static Idal MyDal;

        #region Constructor

        private BL_Basic() { }
        static BL_Basic()
        {
               MyDal = Dal_imp.Instance;
        }
        #endregion



        public void Add(object obj)
        {
            MyDal.Add(obj);
        }
        public void Remove( object obj)
        {
            MyDal.Remove(obj);
        }

        public void Update( object obj)
        {
            MyDal.Update(obj);
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
