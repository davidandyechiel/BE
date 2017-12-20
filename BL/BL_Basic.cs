﻿using System;
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

        private static Idal MyDal = null;

        #region Constructor

        private BL_Basic() { }
        static BL_Basic()
        {
            if (MyDal == null)
                MyDal = new Dal_imp();

           /* string TypeDAL = ConfigurationSettings.AppSettings.Get("TypeDS");
            // MyDal = DalFactory.getDAL("List");
            MyDal = Dal_imp.getDAL(TypeDAL);*/
        }
        
       


        public void Add(object obj)
        {
            MyDal.Add(obj);
        }
        public void Remove( object obj)
        {
            throw new NotImplementedException();
        }

        public void Update( object obj)
        {
            throw new NotImplementedException();
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
