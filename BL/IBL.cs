using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        List<Nanny> getNannyDS();
        List<Mother> getMotherDS();
        List<Child> getChildDS();
        List<Contract> getContractDS();
        void Add(object obj);
        void Remove(object obj);
        void Update(object obj);
        Contract FindContract(Predicate<Contract> p);
        Child FindChild(Predicate<Child> p);
        Mother FindMother(Predicate<Mother> p);
        Nanny FindNanny(Predicate<Nanny> p);
        bool Exists(object obj);
        IEnumerable<Child> collectBrothers(int id);
        IEnumerable<Contract> FilterBy(Predicate<Contract> p);

        IEnumerable<Contract> FilterBy(IEnumerable<Contract> list, Predicate<Contract> p);


    }
}

        /*
        void addNanny(BE.Nanny nanny);
        void deleteNanny(BE.Nanny nanny);
        void updateNanny(BE.Nanny nanny, string whatToUpdate, object update);

        void addMother(BE.Mother mother);
        void deleteMother(BE.Mother mother);
        void updateMother(BE.Mother mother, string whatToUpdate, object update);

        void addChild(BE.Child child);
        void deleteChild(BE.Child child);
        void updateChild(BE.Child child, string whatToUpdate, object update);

        void addContract(BE.Contract contract);
        void deleteContract(BE.Contract contract);
        void updateContract(BE.Contract contract, string whatToUpdate, object update);
        */


    
/*
    internal class BL_Basic: IBL
    {
        const int MIN_AGE_NANNY = 18;
        DAL.Idal dal;

        //public BL_Basic()//supposed to be c-tor
        //{
        //    dal = DAL.FactoryDal.Getdal();
        //    init();
        //}
        void addNanny(BE.Nanny nanny)
        {
            if (nanny.BirthDate.AddYears(MIN_AGE_NANNY) < DateTime.Today)
                throw new Exception("can not add a nanny under the age of " + MIN_AGE_NANNY);
            else
                dal.addNanny(nanny);
        }
        void deleteNanny(BE.Nanny nanny)
        {
            dal.deleteNanny(nanny);
        }
        void updateNanny(BE.Nanny nanny, string whatToUpdate, object update)
        {
            if (nanny.BirthDate.AddYears(18) < DateTime.Today)
                throw new Exception("can not add a nanny under the age of 18");
            else
                dal.updateNanny(nanny,whatToUpdate,update);
        }
        void addMother(BE.Mother mother)
        {
            dal.addMother(mother);
        }
        void deleteMother(BE.Mother mother)
        {
            dal.deleteMother(mother);
        }
        void updateMother(BE.Mother mother, string whatToUpdate, object update)
        {
            dal.updateMother(mother, whatToUpdate, update);
        }



        void addChild(BE.Child child)
        {
            if (child.Birthday.AddMonths(3) < DateTime.Today)
                throw new Exception("can not add a child under the age of three months");
            else
                dal.addChild(child);
        }
        void deleteChild(BE.Child child)
        {
            dal.deleteChild(child);
        }
        void updateChild(BE.Child child, string whatToUpdate, object update)
        {
            if (child.Birthday.AddMonths(3) < DateTime.Today)
                throw new Exception("can not add a child under the age of three months");
            else
                dal.updateChild(child,whatToUpdate,update);
        }



        void addContract(BE.Contract contract)
        {
            if (contract.hasBrothers)
        }
    }
}*/
