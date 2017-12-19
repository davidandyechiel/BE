using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace DS
{
    class Dal_imp : DataSource, Idal
    {
        public void addChild(Child child)
        {

            if (!(childList.Contains(child)))
                childList.Add(child);
            else throw new Exception("child already exist");
        }

        public void addContract(Contract contract)
        {
            if (!(contractList.Contains(contract)))
                contractList.Add(contract);
            else throw new Exception("contract already exist");
        }

        public void addMother(Mother mother)
        {
            if (!(motherList.Contains(mother)))
                motherList.Add(mother);
            else throw new Exception("mother already exist");
        }

        public void addNanny(Nanny nanny)
        {
            if (!(nannyList.Contains(nanny)))
                nannyList.Add(nanny);
            else throw new Exception("nanny already exist");
        }

        public void deleteChild(Child child)
        {
            if (childList.Contains(child))
                childList.Remove(child);
            else throw new Exception("child is not exist");
        }

        public void deleteContract(Contract contract)
        {
            if (contractList.Contains(contract))
                contractList.Remove(contract);
            else throw new Exception("contract is not exist");
        }

        public void deleteMother(Mother mother)
        {
            if (motherList.Contains(mother))
                motherList.Remove(mother);
            else throw new Exception("mother is not exist");
        }

        public void deleteNanny(Nanny nanny)
        {
            if (nannyList.Contains(nanny))
                nannyList.Remove(nanny);
            else throw new Exception("nanny is not exist");
        }

        public List<Child> getChildList()
        {
            return childList;
        }

        public List<Contract> getContractList()
        {
            return contractList;
        }

        public List<Mother> getMotherList()
        {
            return motherList;
        }

        public List<Nanny> getNannyList()
        {
            return nannyList;
        }


        /// <summary>
        /// update the values in the list, "whatToUpdate" as it write in the class.
        /// </summary>
        /// <param name="child"></param>
        /// <param name="whatToUpdate"></param>
        /// <param name="update"></param>
        public void updateChild(Child child, string whatToUpdate, object update)
        {
            if (childList.Contains(child))
            {
                int index = childList.IndexOf(child);
                switch (whatToUpdate)
                {

                    case ("id"):
                        childList.ElementAt(index).Id = (int)update;
                        break;
                    case ("mothersId"):
                        childList.ElementAt(index).MothersId = (int)update;
                        break;
                    case ("fName"):
                        childList.ElementAt(index).FName = (string)update;
                        break;
                    case ("lName"):
                        childList.ElementAt(index).LName = (string)update;
                        break;
                    case ("spacialNeeds"):
                        childList.ElementAt(index).SpacialNeeds = (bool)update;
                        break;
                    case ("spacialNeedsDescription"):
                        childList.ElementAt(index).SpacialNeedsDescription = (string)update;
                        break;
                    case ("birthday"):
                        childList.ElementAt(index).Birthday = (DateTime)update;
                        break;
                    default:
                        throw new Exception("didnt found the value / value cannot be change");
                }

            }
            else throw new Exception("child is not exist");
        }

        public void updateContract(Contract contract, string whatToUpdate, object update)
        {
            if (contractList.Contains(contract))
            {
                int index = childList.IndexOf(contract);
                switch (whatToUpdate)
                {



                    int contractNum;
        private int nannysID;
        private int childID;
        bool hadMeeting;
        bool isSigned;
        private double wagesPerHour;
        private double wagesPerMonth;
        private bool ishourly;//are the wages hourly or monthly
        private DateTime startDate;
        private DateTime endDate;

                    case ("contractNum"):
                        contractList.ElementAt(index).Id = (int)update;
                        break;
                    case ("mothersId"):
                        contractList.ElementAt(index).MothersId = (int)update;
                        break;
                    case ("fName"):
                        contractList.ElementAt(index).FName = (string)update;
                        break;
                    case ("lName"):
                        contractList.ElementAt(index).LName = (string)update;
                        break;
                    case ("spacialNeeds"):
                        contractList.ElementAt(index).SpacialNeeds = (bool)update;
                        break;
                    case ("spacialNeedsDescription"):
                        contractList.ElementAt(index).SpacialNeedsDescription = (string)update;
                        break;
                    case ("birthday"):
                        contractList.ElementAt(index).Birthday = (DateTime)update;
                        break;
                    default:
                        throw new Exception("didnt found the value / value cannot be change");


                }

            }
            else throw new Exception("contract is not exist");
        }

        public void updateMother(Mother mother, string whatToUpdate, object update)
        {
            throw new NotImplementedException();
        }

        public void updateNanny(Nanny nanny, string whatToUpdate, object update)
        {
            throw new NotImplementedException();
        }


        /* static void Add(List<object> objList, object obj)
         {
             if (!(objList.Exists(obj))) // why???
                 objList.Add(obj);
             else throw new Exception(obj + "is already exist");
         }

         static void Remove(List<object> objList, object obj)
         {
             if (objList.Exists(obj)) // why???
                 objList.Remove(obj);
             else throw new Exception(obj + "is not exist");
         }

         static void Update(List<object> objList, object obj, string whatToUpdate, object update)
         {
             if (!(objList.Exists(obj))) // why???
                 objList.Add(obj);
             else throw new Exception(obj + "not exist");
         }*/





    }
}
