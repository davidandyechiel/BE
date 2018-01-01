using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        void Add<T>(T obj);
        void Remove<T>(T obj);
        void Update<T>(T obj);


        List<Nanny> NannyDS { get; }

        List<Mother> MotherDS { get; }
        List<Child> ChildDS { get; }

        List<Contract> ContractDS { get; }

        Contract FindContract(Predicate<Contract> p);
        Child FindChild(Predicate<Child> p);
        Mother FindMother(Predicate<Mother> p);
        Nanny FindNanny(Predicate<Nanny> p);

     






        /*void addNanny(BE.Nanny nanny);
        void deleteNanny(BE.Nanny nanny);
        void updateNanny(BE.Nanny nanny);

        void addMother(BE.Mother mother);
        void deleteMother(BE.Mother mother);
        void updateMother(BE.Mother mother);

        void addChild(BE.Child child);
        void deleteChild(BE.Child child);
        void updateChild(BE.Child child);

        void addContract(BE.Contract contract);
        void deleteContract(BE.Contract contract);
        void updateContract(BE.Contract contract);

      List<object> getDB(Type t);
        */


    }
}
