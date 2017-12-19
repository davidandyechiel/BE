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
        static void Add(List<object> objList, object obj)
        {
            if (!(objList.Exists(obj.Equals))) 
                objList.Add(obj);
            else throw new Exception(obj + "is already exist");
        }
        public void addChild(Child child)
        {

            if (!(childList.Exists(x => x.Id == child.Id)))
                childList.Add(child);
            else throw new Exception("child already exist");
        }

        public void addContract(Contract contract)
        {
            if (!(contractList.Exists(x => x.ContractNum == contract.ContractNum)))
            {
                if (!(nannyList.Exists(x => x.Id == contract.NannysID)))
                    throw new Exception("The nanny in that cpntract is not exist");
                // if (!(motherList.Exists(x => x.Id == childList.Find(x=> x.MothersId == contract.ChildID)) ))
                throw new Exception("The mother in that cpntract is not exist");
                contract.ContractNum = Contract.ContractNumCounter;
                Contract.ContractNumCounter++;
                contractList.Add(contract);
            }
            else throw new Exception("contract already exist");
        }

        public void addMother(Mother mother)
        {
            if (!(motherList.Exists(x=> x.Id == mother.Id)))
                motherList.Add(mother);
            else throw new Exception("mother already exist");
        }

        public void addNanny(Nanny nanny)
        {
            if (!(nannyList.Exists(x => x.Id == nanny.Id)))
                nannyList.Add(nanny);
            else throw new Exception("nanny already exist");
        }

        public void deleteChild(Child child)
        {
            if (childList.Exists(x => x.Id == child.Id))
                childList.Remove(child);
            else throw new Exception("child is not exist");
        }

        public void deleteContract(Contract contract)
        {
            if (contractList.Exists(x => x.ContractNum == contract.ContractNum))
                contractList.Remove(contract);
            else throw new Exception("contract is not exist");
        }

        public void deleteMother(Mother mother)
        {
            if (motherList.Exists(x => x.Id == mother.Id))
                motherList.Remove(mother);
            else throw new Exception("mother is not exist");
        }

        public void deleteNanny(Nanny nanny)
        {
            if (nannyList.Exists(x => x.Id == nanny.Id))
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

        public void updateChild(Child child)
        {
            if (childList.Exists(x => x.Id == child.Id))
            {
                childList.RemoveAt(childList.FindIndex(x => x.Id == child.Id));
                addChild(child);
            }
            else throw new Exception("child is not exist");
        }

        public void updateContract(Contract contract)
        {
            if (contractList.Exists(x => x.Id == contract.Id))
            {
                contractList.RemoveAt(contractList.FindIndex(x => x.Id == contract.Id));
                contractList.Add(contract);
            }
            else throw new Exception("contract is not exist");
        }

        public void updateMother(Mother mother)
        {
            throw new NotImplementedException();
        }

        public void updateNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }


        /*

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
                int index = contractList.IndexOf(contract);
                switch (whatToUpdate)
                {
                    case ("nannysID"):
                        contractList.ElementAt(index).NannysID = (int)update;
                        break;
                    case ("childID"):
                        contractList.ElementAt(index).ChildID = (int)update;
                        break;
                    case ("hadMeeting"):
                        contractList.ElementAt(index).HadMeeting = (bool)update;
                        break;
                    case ("isSigned"):
                        contractList.ElementAt(index).IsSigned = (bool)update;
                        break;
                    case ("ishourly"):
                        contractList.ElementAt(index).Ishourly = (bool)update;
                        break;
                    case ("wagesPerHour"):
                         if (contractList.ElementAt(index).Ishourly)
                                contractList.ElementAt(index).WagesPerHour = (double)update;
                            else throw new Exception("The Nanny isnt working hourly");
                        break;
                    case ("wagesPerMonth"):
                        contractList.ElementAt(index).WagesPerMonth = (double)update;
                        break;
                    case ("startDate"):
                        contractList.ElementAt(index).StartDate = (DateTime)update;
                        break;
                    case ("endDate"):
                        contractList.ElementAt(index).EndDate = (DateTime)update;
                        break;
                    default:
                        throw new Exception("didnt found the value / value cannot be change");
                }
            }
            else throw new Exception("contract is not exist");
        }

        public void updateMother(Mother mother, string whatToUpdate, object update)
        {
            if (motherList.Contains(mother))
            {
                int index = motherList.IndexOf(mother);
                switch (whatToUpdate)
                {
                    case ("id"):
                        motherList.ElementAt(index).Id = (int)update;
                        break;
                    case ("homePhoneNum"):
                        motherList.ElementAt(index).HomePhoneNum = (int)update;
                        break;
                    case ("cellPhoneNum"):
                        motherList.ElementAt(index).CellPhoneNum = (int)update;
                        break;
                    case ("hoursNeeded"):
                        motherList.ElementAt(index).HoursNeeded = (int)update;
                        break;
                    case ("daysNeeded"):
                        motherList.ElementAt(index).DaysNeeded = (int)update;
                        break;
                    case ("lastName"):
                        motherList.ElementAt(index).LastName = (string)update;
                        break;
                    case ("firstName"):
                        motherList.ElementAt(index).FirstName = (string)update;
                        break;
                    case ("address"):
                        motherList.ElementAt(index).Address = (string)update;
                        break;
                    case ("addressNearHere"):
                        motherList.ElementAt(index).AddressNearHere = (string)update;
                        break;
                    case ("notes"):
                        motherList.ElementAt(index).Notes = (string)update;
                        break;
                    case ("needNanny"):
                        motherList.ElementAt(index).NeedNanny = (bool[])update;
                        break;
                    case ("hoursTable"):
                        motherList.ElementAt(index).HoursTable = (HoursInDay)update;
                        break;
                    default:
                        throw new Exception("didnt found the value / value cannot be change");
                }
            }
            else throw new Exception("contract is not exist");
        }

        public void updateNanny(Nanny nanny, string whatToUpdate, object update)
        {
            if (nannyList.Contains(nanny))
            {
                int index = nannyList.IndexOf(nanny);
                switch (whatToUpdate)
                {
                    case ("id"):
                        nannyList.ElementAt(index).Id = (int)update;
                        break;
                    case ("phoneNum"):
                        nannyList.ElementAt(index).PhoneNum = (int)update;
                        break;
                    case ("floor"):
                        nannyList.ElementAt(index).Floor = (int)update;
                        break;
                    case ("experince"):
                        nannyList.ElementAt(index).Experince = (int)update;
                        break;
                    case ("maxCapacity"):
                        nannyList.ElementAt(index).MaxCapacity = (int)update;
                        break;
                    case ("lastName"):
                        nannyList.ElementAt(index).LastName = (string)update;
                        break;
                    case ("firstName"):
                        nannyList.ElementAt(index).LastName = (string)update;
                        break;
                    case ("adress"):
                        nannyList.ElementAt(index).LastName = (string)update;
                        break;
                    case ("recommendations"):
                        nannyList.ElementAt(index).LastName = (string)update;
                        break;
                    case ("minAge"):
                        nannyList.ElementAt(index).LastName = (double)update;
                        break;
                    case ("maxAge"):
                        nannyList.ElementAt(index).LastName = (double)update;
                        break;
                    case ("hourRate"):
                        nannyList.ElementAt(index).LastName = (double)update;
                        break;
                    case ("monthlyRate"):
                        nannyList.ElementAt(index).LastName = (double)update;
                        break;




        private DateTime birthDate;
        
        private bool elevator; // if ther is elevator in the bulding
        
       
        private double minAge; // min age of the childen
        private double maxAge; // max age of childern
        private bool perHour; // if the nanny is also wokring hourly payment
        private double hourRate; // the hourly Rate of the nanny
        private double monthlyRate; // the monthly Rate of the nanny
       
        private bool dependedDaysOff; // if the nanny's Day-Offs depend on the goverment
        private bool[] daysOfWork; // which days is the nanny work
        private HoursInDay[] hoursTable;//table that stores the start and end time of each day of the week







                    case ("homePhoneNum"):
                        motherList.ElementAt(index).HomePhoneNum = (int)update;
                        break;
                    case ("cellPhoneNum"):
                        motherList.ElementAt(index).CellPhoneNum = (int)update;
                        break;
                    case ("hoursNeeded"):
                        motherList.ElementAt(index).HoursNeeded = (int)update;
                        break;
                    case ("daysNeeded"):
                        motherList.ElementAt(index).DaysNeeded = (int)update;
                        break;
                    case ("lastName"):
                        motherList.ElementAt(index).LastName = (string)update;
                        break;
                    case ("firstName"):
                        motherList.ElementAt(index).FirstName = (string)update;
                        break;
                    case ("address"):
                        motherList.ElementAt(index).Address = (string)update;
                        break;
                    case ("addressNearHere"):
                        motherList.ElementAt(index).AddressNearHere = (string)update;
                        break;
                    case ("notes"):
                        motherList.ElementAt(index).Notes = (string)update;
                        break;
                    case ("needNanny"):
                        motherList.ElementAt(index).NeedNanny = (bool[])update;
                        break;
                    case ("hoursTable"):
                        motherList.ElementAt(index).HoursTable = (HoursInDay)update;
                        break;
                    default:
                        throw new Exception("didnt found the value / value cannot be change");
                }
            }
            else throw new Exception("contract is not exist");
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
