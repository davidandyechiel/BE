using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using BE;
using DAL;
using DS;

namespace DS
{
    public sealed class Dal_XML_imp : Idal
    {

        //TODO: save the lists and update the file when needed

        XElement nannyRoot;
        string nannyPath = @"NannyXml.xml";


        XElement contractRoot;
        string contractPath = @"ContractXml.xml";


        XElement childRoot;
        string childPath = @"ChildXml.xml";


        XElement motherRoot;
        string motherPath = @"MotherXml.xml";


        #region Singletone
        private static readonly Dal_XML_imp instance = new Dal_XML_imp();

        public static Dal_XML_imp Instance
        {
            get { return instance; }
        }


        #endregion
        #region Ctrs
        private Dal_XML_imp()
        {
            if (!File.Exists(nannyPath))
                CreateFiles(EnumClasses.E_type.NANNY);
            else LoadData(EnumClasses.E_type.NANNY);
            if (!File.Exists(contractPath))
                CreateFiles(EnumClasses.E_type.CONTRACT);
            else LoadData(EnumClasses.E_type.CONTRACT);
            if (!File.Exists(childPath))
                CreateFiles(EnumClasses.E_type.CHILD);
            else LoadData(EnumClasses.E_type.CHILD);
            if (!File.Exists(motherPath))
                CreateFiles(EnumClasses.E_type.MOTHER);
            else LoadData(EnumClasses.E_type.MOTHER);

        }

        #endregion

        #region loadingFiels
        private void CreateFiles(BE.EnumClasses.E_type type)
        {
            switch (type)
            {
                case EnumClasses.E_type.CHILD:
                    childRoot = new XElement("nannys");
                    childRoot.Save(childPath);

                    break;
                case EnumClasses.E_type.CONTRACT:
                    contractRoot = new XElement("contracts");
                    contractRoot.Save(contractPath);

                    break;
                case EnumClasses.E_type.MOTHER:
                    motherRoot = new XElement("mothers");
                    motherRoot.Save(motherPath);

                    break;
                case EnumClasses.E_type.NANNY:
                    nannyRoot = new XElement("children");
                    nannyRoot.Save(nannyPath);

                    break;
                default:
                    throw new Exception("error loading file");

            }

        }


        private void LoadData(EnumClasses.E_type type)
        {
            switch (type)
            {
                case EnumClasses.E_type.CHILD:
                    childRoot = XElement.Load(nannyPath);
                    break;
                case EnumClasses.E_type.CONTRACT:
                    contractRoot = XElement.Load(nannyPath);
                    break;
                case EnumClasses.E_type.MOTHER:
                    motherRoot = XElement.Load(nannyPath);
                    break;
                case EnumClasses.E_type.NANNY:
                    nannyRoot = XElement.Load(nannyPath);
                    break;
                default:
                    throw new Exception("File upload problem");
            }
        }

        #endregion
        void Add<T>(T obj);
        void Remove<T>(T obj);
        void Update<T>(T obj);

        #region GeneralSection



        #endregion


        #region nannySection
        public List<Nanny> NannyDS()
        {


            LoadData(EnumClasses.E_type.NANNY);
            List<Nanny> nannys = new List<Nanny>();
            try
            {
                DateTime[][] b = new DateTime[6][];
                for (int i = 0; i < 6; i++)
                {
                    b[i] = new DateTime[2];
                }
                nannys = (from nan in nannyRoot.Elements()
                          select new Nanny()
                          {
                              Id = int.Parse(nan.Element("id").Value),

                              FirstName = nan.Element("firstName").Value,
                              LastName = nan.Element("lastName").Value,
                              Adress = nan.Element("adress").Value,
                              BirthDate = new DateTime(Convert.ToInt32(nan.Element("birthDate").Element("year").Value),
                                                     Convert.ToInt32(nan.Element("birthDate").Element("month").Value),
                                                     Convert.ToInt32(nan.Element("birthDate").Element("day").Value)),
                              PhoneNum = int.Parse(nan.Element("phoneNum").Value),
                              Elevator = bool.Parse(nan.Element("elevator").Value),
                              Floor = int.Parse(nan.Element("floor").Value),
                              Experince = int.Parse(nan.Element("experience").Value),
                              HourRate = int.Parse(nan.Element("hourRate").Value),
                              MaxAge = int.Parse(nan.Element("maxAge").Value),
                              MinAge = int.Parse(nan.Element("minAge").Value),
                              MaxCapacity = int.Parse(nan.Element("maxCapacity").Value),
                              MonthlyRate = int.Parse(nan.Element("MonthlyRate").Value),
                              PerHour = bool.Parse(nan.Element("perhour").Value),
                              Recommendations = nan.Element("recommendations").Value,


                          }).ToList();


            }
            return nannys;
        }

        //public string GetNannyName(int id)
        //{
        //    LoadData();
        //    string nannyName;
        //    try
        //    {
        //        nannyName = (from nan in nannyRoot.Elements()
        //                       where int.Parse(nan.Element("id").Value) == id
        //                       select nan.Element("firstName").Value
        //                       + " " +
        //                           nan.Element("lastName").Value
        //                            ).FirstOrDefault();
        //    }
        //    catch
        //    {
        //        nannyName = null;
        //    }
        //    return nannyName;
        //}

        public void AddNanny(Nanny nanny)
        {
            XElement id = new XElement("id", nanny.Id);
            XElement firstName = new XElement("firstName", nanny.FirstName);
            XElement lastName = new XElement("lastName", nanny.LastName);
            //XElement name = new XElement("name", firstName, lastName);
            XElement birthdate = new XElement("birthdate", new XElement("year", nanny.BirthDate.Year), new XElement("month", nanny.BirthDate.Month), new XElement("day", nanny.BirthDate.Day));
            XElement adress = new XElement("adress", nanny.Adress);
            XElement phoneNum = new XElement("phoneNum", nanny.PhoneNum);
            XElement elevator = new XElement("elevator", nanny.Elevator);
            XElement floor = new XElement("floor", nanny.Floor);
            XElement experience = new XElement("experience", nanny.Experince);
            XElement hourRate = new XElement("hourRate", nanny.HourRate);
            XElement maxAge = new XElement("maxAge", nanny.MaxAge);
            XElement minAge = new XElement("minAge", nanny.MinAge);
            XElement maxCapacity = new XElement("maxCapacity", nanny.MaxCapacity);
            XElement monthlyRate = new XElement("monthlyRate", nanny.MonthlyRate);
            XElement perHour = new XElement("perHour", nanny.PerHour);
            XElement recommendations = new XElement("recommendations", nanny.Recommendations);
            XElement dependedDaysOff = new XElement("dependedDaysOff", nanny.DependedDaysOff);
            XElement difference = new XElement("difference", nanny.Difference);
            XElement dthoursTable = new XElement("dthoursTable",
                                                         new XElement("sunday",
                                                                      new XElement("start",
                                                                                            new XElement("hour", (nanny.DThoursTable)[0][0].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[0][0].Minute)),
                                                                      new XElement("end",
                                                                                            new XElement("hour", (nanny.DThoursTable)[0][1].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[0][1].Minute))),
                                                         new XElement("monday",
                                                                      new XElement("start",
                                                                                            new XElement("hour", (nanny.DThoursTable)[1][0].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[1][0].Minute)),
                                                                      new XElement("end",
                                                                                            new XElement("hour", (nanny.DThoursTable)[1][1].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[1][1].Minute))),
                                                         new XElement("tuesday",
                                                                      new XElement("start",
                                                                                            new XElement("hour", (nanny.DThoursTable)[2][0].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[2][0].Minute)),
                                                                      new XElement("end",
                                                                                            new XElement("hour", (nanny.DThoursTable)[2][1].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[2][1].Minute))),
                                                         new XElement("wednesday",
                                                                      new XElement("start",
                                                                                            new XElement("hour", (nanny.DThoursTable)[3][0].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[3][0].Minute)),
                                                                      new XElement("end",
                                                                                            new XElement("hour", (nanny.DThoursTable)[3][1].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[3][1].Minute))),
                                                         new XElement("thursday",
                                                                      new XElement("start",
                                                                                            new XElement("hour", (nanny.DThoursTable)[4][0].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[4][0].Minute)),
                                                                      new XElement("end",
                                                                                            new XElement("hour", (nanny.DThoursTable)[4][1].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[4][1].Minute))),
                                                         new XElement("friday",
                                                                      new XElement("start",
                                                                                            new XElement("hour", (nanny.DThoursTable)[5][0].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[5][0].Minute)),
                                                                      new XElement("end",
                                                                                            new XElement("hour", (nanny.DThoursTable)[6][1].Hour),
                                                                                            new XElement("minute", (nanny.DThoursTable)[6][1].Minute))));

            nannyRoot.Add(new XElement("nanny", id, firstName, lastName, birthdate, adress, phoneNum, elevator, floor, experience, maxAge, minAge, maxCapacity, monthlyRate
                , perHour, recommendations, dependedDaysOff, difference, dthoursTable));
            nannyRoot.Save(nannyPath);
        }

        public bool RemoveNanny(int id)
        {
            XElement nannyElement;
            try
            {
                nannyElement = (from p in nannyRoot.Elements()
                                where Convert.ToInt32(p.Element("id").Value) == id
                                select p).FirstOrDefault();
                nannyElement.Remove();
                nannyRoot.Save(nannyPath);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void UpdateNanny(Nanny nanny)
        {
            XElement nannyElement = (from p in nannyRoot.Elements()
                                     where Convert.ToInt32(p.Element("id").Value) == nanny.Id
                                     select p).FirstOrDefault();
            //   XElement studentElement2 = studentRoot.Elements().Where(p => Convert.ToInt32(p.Element("id").Value) == student.Id).FirstOrDefault();
            nannyElement.Element("firstName").Value = nanny.FirstName;
            nannyElement.Element("lastName").Value = nanny.LastName;
            nannyElement.Element("adress").Value = nanny.Adress;
            nannyElement.Element("birthDate").Element("year").Value = nanny.BirthDate.Year.ToString();
            nannyElement.Element("birthDate").Element("month").Value = nanny.BirthDate.Month.ToString();
            nannyElement.Element("birthDate").Element("day").Value = nanny.BirthDate.Day.ToString();
            nannyElement.Element("phoneNum").Value = nanny.PhoneNum.ToString();
            nannyElement.Element("elevator").Value = nanny.Elevator.ToString();
            nannyElement.Element("floor").Value = nanny.Floor.ToString();
            nannyElement.Element("experience").Value = nanny.Experince.ToString();
            nannyElement.Element("hourRate").Value = nanny.HourRate.ToString();
            nannyElement.Element("maxAge").Value = nanny.MaxAge.ToString();
            nannyElement.Element("minAge").Value = nanny.MinAge.ToString();
            nannyElement.Element("maxCapacity").Value = nanny.MaxCapacity.ToString();
            nannyElement.Element("monthlyRate").Value = nanny.MonthlyRate.ToString();
            nannyElement.Element("perHour").Value = nanny.PerHour.ToString();
            nannyElement.Element("recomendations").Value = nanny.Recommendations;
            nannyElement.Element("dependedDaysOff").Value = nanny.DependedDaysOff.ToString();
            nannyElement.Element("difference").Value = nanny.Difference.ToString();

            nannyRoot.Save(nannyPath);
        }
        #endregion
        #region childSection

        public void AddChild(Child child)
        {
            XElement id = new XElement("id", child.Id);
            XElement mothersId = new XElement("mothersId", child.MothersId);
            XElement IDs = new XElement("IDs", mothersId, id);
            XElement fName = new XElement("fName", child.FName);
            XElement lName = new XElement("lName", child.LName);
            XElement name = new XElement("name", fName, lName);
            XElement birthdate = new XElement("birthdate",
                                               new XElement("year", child.Birthday.Year),
                                               new XElement("month", child.Birthday.Month),
                                               new XElement("day", child.Birthday.Day));
            XElement gender = new XElement("gender", child.FName);
            XElement spacialNeeds = new XElement("spacialNeeds", child.SpacialNeeds);
            XElement spacialNeedsDescription = new XElement("spacialNeedsDescription", child.SpacialNeedsDescription);
            XElement spacials = new XElement("spacials", spacialNeeds, spacialNeedsDescription);

            childRoot.Add(new XElement("child", IDs, name, birthdate, gender, spacials));
            childRoot.Save(childPath);
        }





        //child get DS
        public List<Child> childDS()
        {
            LoadData(EnumClasses.E_type.CHILD);
            List<Child> children = new List<Child>();
            try
            {
                children = (from ch in childRoot.Elements()
                            select new Child()
                            {
                                Id = int.Parse(ch.Element("id").Value),
                                MothersId = int.Parse(ch.Element("mothersId").Value),
                                FName = ch.Element("name").Element("fName").Value,
                                LName = ch.Element("name").Element("lName").Value,
                                Gender = converToGender(ch.Element("gender").Value),
                                SpacialNeeds = bool.Parse(ch.Element("spacialNeeds").Value),
                                SpacialNeedsDescription = (ch.Element("spacialNeedsDescription").Value),
                                Birthday = new DateTime(Convert.ToInt32(ch.Element("birthday").Element("year").Value),
                                                       Convert.ToInt32(ch.Element("birthday").Element("month").Value),
                                                       Convert.ToInt32(ch.Element("birthday").Element("day").Value))
                            }).ToList();


            }
            catch (Exception exp)
            {
                throw exp;
            }
            return children;
        }

        public static EnumClasses.E_gender converToGender(string str)
        {
            if (str == "BOY")
                return EnumClasses.E_gender.BOY;
            else return EnumClasses.E_gender.GIRL;
        }

        //public string GetNannyName(int id)
        //{
        //    LoadData();
        //    string nannyName;
        //    try
        //    {
        //        nannyName = (from nan in nannyRoot.Elements()
        //                       where int.Parse(nan.Element("id").Value) == id
        //                       select nan.Element("firstName").Value
        //                       + " " +
        //                           nan.Element("lastName").Value
        //                            ).FirstOrDefault();
        //    }
        //    catch
        //    {
        //        nannyName = null;
        //    }
        //    return nannyName;
        //}

        public Child FindChild(int id)
        {
            LoadData(EnumClasses.E_type.CHILD);
            Child child;
            try
            {
                child = (from ch in childRoot.Elements()

                         where int.Parse(ch.Element("id").Value) == id
                         select new Child()
                         {
                             Id = int.Parse(ch.Element("id").Value),
                             MothersId = int.Parse(ch.Element("mothersId").Value),
                             FName = ch.Element("name").Element("fName").Value,
                             LName = ch.Element("name").Element("lName").Value,
                             Gender = converToGender(ch.Element("gender").Value),
                             SpacialNeeds = bool.Parse(ch.Element("spacialNeeds").Value),
                             SpacialNeedsDescription = (ch.Element("spacialNeedsDescription").Value),
                             Birthday = new DateTime(Convert.ToInt32(ch.Element("birthday").Element("year").Value),
                                                   Convert.ToInt32(ch.Element("birthday").Element("month").Value),
                                                   Convert.ToInt32(ch.Element("birthday").Element("day").Value))
                         }).FirstOrDefault();
                return child;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        public Child FindChild(Predicate<Child> p)
        {
            LoadData(EnumClasses.E_type.CHILD);
            Child child;
            try
            {
                child = (from ch in childRoot.Elements()

                         where
                         p(new Child()
                         {
                             Id = int.Parse(ch.Element("id").Value),
                             MothersId = int.Parse(ch.Element("mothersId").Value),
                             FName = ch.Element("name").Element("fName").Value,
                             LName = ch.Element("name").Element("lName").Value,
                             Gender = converToGender(ch.Element("gender").Value),
                             SpacialNeeds = bool.Parse(ch.Element("spacialNeeds").Value),
                             SpacialNeedsDescription = (ch.Element("spacialNeedsDescription").Value),
                             Birthday = new DateTime(Convert.ToInt32(ch.Element("birthday").Element("year").Value),
                                                   Convert.ToInt32(ch.Element("birthday").Element("month").Value),
                                                   Convert.ToInt32(ch.Element("birthday").Element("day").Value))
                         })
                         select new Child()
                         {
                             Id = int.Parse(ch.Element("id").Value),
                             MothersId = int.Parse(ch.Element("mothersId").Value),
                             FName = ch.Element("name").Element("fName").Value,
                             LName = ch.Element("name").Element("lName").Value,
                             Gender = converToGender(ch.Element("gender").Value),
                             SpacialNeeds = bool.Parse(ch.Element("spacialNeeds").Value),
                             SpacialNeedsDescription = (ch.Element("spacialNeedsDescription").Value),
                             Birthday = new DateTime(Convert.ToInt32(ch.Element("birthday").Element("year").Value),
                                                   Convert.ToInt32(ch.Element("birthday").Element("month").Value),
                                                   Convert.ToInt32(ch.Element("birthday").Element("day").Value))
                         }).FirstOrDefault();
                return child;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }







        public bool RemoveNanny(int id)
        {
            XElement nannyElement;
            try
            {
                nannyElement = (from p in nannyRoot.Elements()
                                where Convert.ToInt32(p.Element("id").Value) == id
                                select p).FirstOrDefault();
                nannyElement.Remove();
                nannyRoot.Save(nannyPath);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void UpdateNanny(Nanny nanny)
        {
            XElement nannyElement = (from p in nannyRoot.Elements()
                                     where Convert.ToInt32(p.Element("id").Value) == nanny.Id
                                     select p).FirstOrDefault();
            //   XElement studentElement2 = studentRoot.Elements().Where(p => Convert.ToInt32(p.Element("id").Value) == student.Id).FirstOrDefault();
            nannyElement.Element("firstName").Value = nanny.FirstName;
            nannyElement.Element("lastName").Value = nanny.LastName;
            nannyElement.Element("adress").Value = nanny.Adress;
            nannyElement.Element("birthDate").Element("year").Value = nanny.BirthDate.Year.ToString();
            nannyElement.Element("birthDate").Element("month").Value = nanny.BirthDate.Month.ToString();
            nannyElement.Element("birthDate").Element("day").Value = nanny.BirthDate.Day.ToString();
            nannyElement.Element("phoneNum").Value = nanny.PhoneNum.ToString();
            nannyElement.Element("elevator").Value = nanny.Elevator.ToString();
            nannyElement.Element("floor").Value = nanny.Floor.ToString();
            nannyElement.Element("experience").Value = nanny.Experince.ToString();
            nannyElement.Element("hourRate").Value = nanny.HourRate.ToString();
            nannyElement.Element("maxAge").Value = nanny.MaxAge.ToString();
            nannyElement.Element("minAge").Value = nanny.MinAge.ToString();
            nannyElement.Element("maxCapacity").Value = nanny.MaxCapacity.ToString();
            nannyElement.Element("monthlyRate").Value = nanny.MonthlyRate.ToString();
            nannyElement.Element("perHour").Value = nanny.PerHour.ToString();
            nannyElement.Element("recomendations").Value = nanny.Recommendations;
            nannyElement.Element("dependedDaysOff").Value = nanny.DependedDaysOff.ToString();
            nannyElement.Element("difference").Value = nanny.Difference.ToString();

            nannyRoot.Save(nannyPath);
        }
        #endregion






        public void Add<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public Contract FindContract(Predicate<Contract> p)
        {
            throw new NotImplementedException();
        }

        public Child FindChild(Predicate<Child> p)
        {
            throw new NotImplementedException();
        }

        public Mother FindMother(Predicate<Mother> p)
        {
            throw new NotImplementedException();
        }

        public Nanny FindNanny(Predicate<Nanny> p)
        {
            throw new NotImplementedException();
        }

        public bool Exists(object obj)
        {
            throw new NotImplementedException();
        }
    }

}
/* TODO:
       public List<Nanny> NannyDS
       {
           get
           {
               throw new NotImplementedException();
           }
       }

       public List<Mother> MotherDS
       {
           get
           {
               throw new NotImplementedException();
           }
       }

       public List<Child> ChildDS
       {
           get
           {
               throw new NotImplementedException();
           }
       }

       public List<Contract> ContractDS
       {
           get
           {
               throw new NotImplementedException();
           }
       }*/






/*
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
                    case (EnumClasses.E_type.CONTRACT):
                        if (!(MyDS.getMotherDS().Exists(x => x.Id == (MyDS.getChildDS().Find(y => y.Id == ((obj as Contract).ChildID)).MothersId))))
                            //if the mother's Id of the child in the contract is not exist in the motherlist
                            throw new Exception("the mother is not exist in the DS");
                        if (!(MyDS.getNannyDS().Exists(x => x.Id == ((obj as Contract).NannysID))))
                            //if the nanny's Id  in the contract is not exist in the nannylist
                            throw new Exception("the nanny is not exist in the DS");
                        //else add new contract number
                        if ((obj as Contract).ContractNum == 0)
                            (obj as Contract).ContractNum = getContractNum(obj as Contract);
                        MyDS.getContractDS().Add(obj as Contract);
                        break;
                    case (EnumClasses.E_type.CHILD):
                        MyDS.getChildDS().Add(obj as Child);
                        break;
                    case (EnumClasses.E_type.MOTHER):
                        MyDS.getMotherDS().Add(obj as Mother);
                        break;
                    case (EnumClasses.E_type.NANNY):
                        MyDS.getNannyDS().Add(obj as Nanny);
                        break;
                    default:
                        break;
                }
            else throw new Exception(obj + "is already exist");
        }

        private int getContractNum(Contract contract)
        {

                return Contract.ContractNumCounter++; // return the current contract number and add 1 to the contract number

        }

        public bool Exists(object obj)
        {
            switch (getEnum(obj))
            {
                case (EnumClasses.E_type.CONTRACT):
                    return MyDS.getContractDS().Exists((obj as Contract).Equals);
                case (EnumClasses.E_type.CHILD):
                    return MyDS.getChildDS().Exists((obj as Child).Equals);
                case (EnumClasses.E_type.MOTHER):
                    return MyDS.getMotherDS().Exists((obj as Mother).Equals);
                case (EnumClasses.E_type.NANNY):
                    return MyDS.getNannyDS().Exists((obj as Nanny).Equals);
                default:
                    throw new Exception(obj + "cannot be Added");
            }
        }
        

        public void Remove<T>(T obj)
        {
            if (Exists(obj)) // it the object is exist
                switch (getEnum(obj))
                {
                    case (EnumClasses.E_type.CONTRACT):
                        MyDS.getContractDS().RemoveAt(MyDS.getContractDS().FindIndex(obj.Equals));
                        break;
                    case (EnumClasses.E_type.CHILD):
                        MyDS.getChildDS().RemoveAt(MyDS.getChildDS().FindIndex(obj.Equals));
                        break;
                    case (EnumClasses.E_type.MOTHER):
                        MyDS.getMotherDS().RemoveAt(MyDS.getMotherDS().FindIndex(obj.Equals));
                        break;
                    case (EnumClasses.E_type.NANNY):
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
                    case (EnumClasses.E_type.CONTRACT):
                        (obj as Contract).ContractNum = FindContract(x=> x.ChildID == (obj as Contract).ChildID && x.NannysID == (obj as Contract).NannysID).ContractNum;
                        Remove(obj as Contract);
                        Add(obj as Contract);
                        break;
                    case (EnumClasses.E_type.CHILD):
                        Remove(obj as Child);
                        Add(obj as Child);
                        break;
                    case (EnumClasses.E_type.MOTHER):
                        Remove(obj as Mother);
                        Add(obj as Mother);
                        break;
                    case (EnumClasses.E_type.NANNY):
                        Remove(obj as Nanny);
                        Add(obj as Nanny);
                        break;
                    default:
                        throw new Exception("Cannot update unknown type");
                }
            else throw new Exception(obj + "is not exist");

        }

        #region property
        public List<Child> ChildDS
        {
            get
            {
                return MyDS.getChildDS();
            }
        }

        public List<Contract> ContractDS
        {
            get
            {
                return MyDS.getContractDS();
            }
        }

        public List<Nanny> NannyDS
        {
            get
            {
                return MyDS.getNannyDS();
            }
        }

        public List<Mother> MotherDS
        {
            get
            {
                return MyDS.getMotherDS();
            }
        }

        #endregion


        public static EnumClasses.E_type getEnum(object obj)
        {

            if (obj is Contract)
                return EnumClasses.E_type.CONTRACT;
            if (obj is Child)
                return EnumClasses.E_type.CHILD;
            if (obj is Mother)
                return EnumClasses.E_type.MOTHER;
            if (obj is Nanny)
                return EnumClasses.E_type.NANNY;
            else throw new Exception("Unknown Type");
        }

        public Contract FindContract(Predicate<Contract> p)
        {
            return MyDS.getContractDS().Find(p);
        }

        public Child FindChild(Predicate<Child> p)
        {
            return MyDS.getChildDS().Find(p);
        }
        public Mother FindMother(Predicate<Mother> p)
        {
            return MyDS.getMotherDS().Find(p);
        }
        public Nanny FindNanny(Predicate<Nanny> p)
        {
            return MyDS.getNannyDS().Find(p);
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









