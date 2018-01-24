using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using BE;


namespace DAL
{
    class Dal_XML_imp
    {
        XElement nannyRoot;
        string nannyPath = @"NannyXml.xml";

        public Dal_XML_imp()
        {
            if (!File.Exists(nannyPath))
                CreateFiles();
            else
                LoadData();
        }

        private void CreateFiles()
        {
            nannyRoot = new XElement("nannys");
            nannyRoot.Save(nannyPath);
        }

        private void LoadData()
        {
            try
            {
                nannyRoot = XElement.Load(nannyPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }


        public List<Nanny> GetNannyList()
        {
            LoadData();
            List<Nanny> nannys;
            try
            {
                nannys = (from nan in nannyRoot.Elements()
                            select new Nanny()
                            {
                                Id = int.Parse(nan.Element("id").Value),
                                
                                FirstName = nan.Element("firstName").Value,
                                LastName = nan.Element("lastName").Value,
                                Adress =nan.Element("adress").Value,
                                BirthDate = new DateTime(Convert.ToInt32(nan.Element("birthDate").Element("year").Value),
                                                       Convert.ToInt32(nan.Element("birthDate").Element("month").Value),
                                                       Convert.ToInt32(nan.Element("birthDate").Element("day").Value)),
                              PhoneNum = int.Parse(nan.Element("phoneNum").Value),
                              Elevator = bool.Parse(nan.Element("elevator").Value),
                              Floor=int.Parse(nan.Element("floor").Value),
                              Experince=int.Parse(nan.Element("experience").Value),
                              HourRate=int.Parse(nan.Element("hourRate").Value),
                              MaxAge=int.Parse(nan.Element("maxAge").Value),
                              MinAge=int.Parse(nan.Element("minAge").Value),
                              MaxCapacity=int.Parse(nan.Element("maxCapacity").Value),
                              MonthlyRate=int.Parse(nan.Element("MonthlyRate").Value),
                              PerHour=bool.Parse(nan.Element("perhour").Value),
                              Recommendations=nan.Element("recommendations").Value,
                              DependedDaysOff = bool.Parse(nan.Element("dependedDaysOff").Value),
                              Difference=int.Parse(nan.Element("difference").Value),
                              

                            }).ToList();
            }
            catch
            {
                nannys = null;
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
            XElement birthdate = new XElement("birthdate", new XElement("year", nanny.BirthDate.Year), new XElement("year", nanny.BirthDate.Month), new XElement("year", nanny.BirthDate.Day));
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


            nannyRoot.Add(new XElement("nanny", id,firstName,lastName,birthdate,adress,phoneNum,elevator,floor,experience,maxAge,minAge,maxCapacity,monthlyRate
                ,perHour,recommendations,dependedDaysOff,difference));
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
            nannyElement.Element("hourRate").Value = nanny.HourRate.ToString() ;
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

    }

}
