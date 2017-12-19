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
        void updateContract(BE.Contract contract);*/

        void Add(List<object> objList , object obj);
        void Remove(List<object> objList, object obj);
        void Update(List<object> objList, object obj);

        List<Nanny> getNannyList();
        List<Mother> getMotherList();
        List<Child> getChildList();
        List<Contract> getContractList();
    }
}
