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
        public List<Nanny> getDependedDayOffsNannies()
        {
            List<Nanny> list = new List<Nanny>();
            foreach (Nanny nanny in getNannyDS())
                if (nanny.DependedDaysOff)
                    list.Add(nanny);
            return list;
        }

        public List<Child> getUnSignedChildren()
        {
            int childId = 0;
            Del isSigned = (x => x.ChildID == childId);


            List<Child> list = new List<Child>();
            foreach (Child child in getChildDS())
            {
                childId = child.Id;
                foreach (Contract cont in getContractDS())
                    if (isSigned(cont)) // if the child in the contract so break;
                        break;
                 list.Add(child); // if there is no Contract for this child and add it to the list 
            }
            return list;
        }



        public delegate bool Del(Contract x);
        public List<Contract> AllTheContractsHow(Del condition)
        {
            List<Contract> list = new List<Contract>();
            foreach (Contract contract in getContract())
                if (condition(contract))
                    list.Add(contract);
            return list;
        }

        public int NumTheContractsHow(Del condition)
        {
            return AllTheContractsHow(condition).Count;

        }

        SignContract(Mother mom , Nanny nanny, Child child)
        {
            Contract


        }
    }
}
