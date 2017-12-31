using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;


namespace DS
{

    public sealed class Dal_imp : Idal
    {
        DataSource MyDS;
        // List<object> DalList;

        #region Singletone
        private static readonly Dal_imp instance = new Dal_imp();

        public static Dal_imp Instance
        {
            get { return instance; }
        }
        #endregion
        #region Ctrs
        private Dal_imp()
        {
            MyDS = DataSource.Instance;
        }

        #endregion

        public void Add<T>(T obj)
        {
            if (!(Exists(obj))) // it the object isnt exist
                switch (getEnum(obj))
                {
                    case (E_type.CONTRACT):
                        if (!(MyDS.getMotherDS().Exists(x => x.Id == (MyDS.getChildDS().Find(y => y.Id == ((obj as Contract).ChildID)).MothersId))))
                            //if the mother's Id of the child in the contract is not exist in the motherlist
                            throw new Exception("the mother is not exist in the DS");
                        if (!(MyDS.getMotherDS().Exists(x => x.Id == ((obj as Contract).NannysID))))
                            //if the nanny's Id  in the contract is not exist in the nannylist
                            throw new Exception("the nanny is not exist in the DS");
                        //else add new contract number
                        (obj as Contract).ContractNum = getContractNum(obj as Contract);
                        MyDS.getContractDS().Add(obj as Contract);
                        break;
                    case (E_type.CHILD):
                        MyDS.getChildDS().Add(obj as Child);
                        break;
                    case (E_type.MOTHER):
                        MyDS.getMotherDS().Add(obj as Mother);
                        break;
                    case (E_type.NANNY):
                        MyDS.getNannyDS().Add(obj as Nanny);
                        break;
                    default:
                        break;
                }
            else throw new Exception(obj + "is already exist");
        }

        private int getContractNum(Contract contract)
        {
            if (contract.ContractNum == 0) // new contract
            {
                return Contract.ContractNumCounter++; // return the current contract number and add 1 to the contract number
            }
            else // update contract
            {
                //return the old cpntract number, find the old one (whith the same nannyId and childId and get his contract.
                return MyDS.getContractDS().Find(contract.Equals).ContractNum; // update Contract number
            }
        }

        private bool Exists(object obj)
        {
            switch (getEnum(obj))
            {
                case (E_type.CONTRACT):
                    return MyDS.getContractDS().Exists(((Contract)obj).Equals);
                case (E_type.CHILD):
                    return MyDS.getChildDS().Exists(((Child)obj).Equals);
                case (E_type.MOTHER):
                    return MyDS.getMotherDS().Exists(((Mother)obj).Equals);
                case (E_type.NANNY):
                    return MyDS.getNannyDS().Exists(((Nanny)obj).Equals);
                default:
                    throw new Exception(obj + "cannot be Added");
            }
        }

        public void Remove<T>(T obj)
        {
            if (Exists(obj)) // it the object is exist
                switch (obj.GetType().ToString())
                {
                    case ("Contract"):
                        MyDS.getContractDS().RemoveAt(MyDS.getContractDS().FindIndex(obj.Equals));
                        break;
                    case ("Child"):
                        MyDS.getChildDS().RemoveAt(MyDS.getChildDS().FindIndex(obj.Equals));
                        break;
                    case ("Mother"):
                        MyDS.getMotherDS().RemoveAt(MyDS.getMotherDS().FindIndex(obj.Equals));
                        break;
                    case ("Nanny"):
                        MyDS.getNannyDS().RemoveAt(MyDS.getNannyDS().FindIndex(obj.Equals));
                        break;
                    default:
                        break;
                }
            else throw new Exception(obj + "is not exist");
        }


        public void Update<T>(T obj)
        {
            if (Exists(obj)) // it the object is exist
                switch (getEnum(obj))
                {
                    case (E_type.CONTRACT):
                        Add(obj as Contract); // relies on the fact that list enters the new object in the end
                        Remove(obj as Contract);
                        break;
                    case (E_type.CHILD):
                        Add(obj as Child); // relies on the fact that list enters the new object in the end
                        Remove(obj as Child);
                        break;
                    case (E_type.MOTHER):
                        Add(obj as Mother); // relies on the fact that list enters the new object in the end
                        Remove(obj as Mother);
                        break;
                    case (E_type.NANNY):
                        Add(obj as Nanny); // relies on the fact that list enters the new object in the end
                        Remove(obj as Nanny);
                        break;
                    default:
                        throw new Exception("Cannot update unknown type");
                }
            else throw new Exception(obj + "is not exist");

        }

        public Idal getChildDS()
        {
            return MyDS.getChildDS();
        }

        public Idal getContractDS()
        {
            return MyDS.getContractDS();
        }

        public Idal getNannyDS()
        {
            return MyDS.getNannyDS();
        }

        public Idal getMotherDS()
        {
            return MyDS.getMotherDS();
        }

        //extention methods
        public static E_type getEnum(object obj)
        {

            if (obj is Contract)
                return E_type.CONTRACT;
            if (obj is Child)
                return E_type.CHILD;
            if (obj is Mother)
                return E_type.MOTHER;
            if (obj is Nanny)
                return E_type.NANNY;
            else throw new Exception("Unknown Type");
        }

        public T Find<T>(Func<T, bool> p)
        {
            throw new NotImplementedException();
        }
    } // Dal_imp
}//namespace









/*
public List<object> GetDB(Type t)
{
    switch (t.ToString())
    {
        case ("Child"):
            return childList;

        case ("Mother"):
            return childList;

        case ("Contract"):
            return childList;

        case ("Nanny"):
            return childList;

        default:
            throw new Exception("no such DB");
    }
}*/








/*  public void addChild(Child child)
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


