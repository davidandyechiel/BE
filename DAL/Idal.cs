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


        void Add( object obj);
        void Remove( object obj);
        void Update( object obj);
        Idal getNannyDS();
        Idal getMotherDS();
        Idal getChildDS();
       Idal getContractDS();


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
