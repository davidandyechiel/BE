using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DS;
using BE;
using GoogleMapsApi.Entities.Directions;
using GoogleMapsApi;


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
        public List<Contract> AllTheContractsHow(Del conditions)
        {

            // IEnumerable<Contract> conditionMakers = MyDal.getContractDS()Select(conditions);
            //       return conditionMakers.ToList();

            //var newArray =MyDal.getContractDS().where(item => item 2 == 0).select(item => item * 2);
            var arr = from item in MyDal.ContractDS where (conditions(item)) select item ;
            return arr.ToList();
            /*List<Contract> list = new List<Contract>();
            foreach (Contract contract in getContractDS())
                if (conditions(contract))
                    list.Add(contract);
            return list;*/
        }
    
        public int CountTheContractsHow(Del condition)
        {
            return (AllTheContractsHow(condition).Count);
        }

        public void SignContract(Mother mom, Nanny nanny, Child child, int nannysID, int childID, bool hadMeeting, bool isSigned, double wages, bool ishourly, DateTime startDate, DateTime endDate)
        {
            Contract newContract = new Contract(nannysID, childID, hadMeeting, isSigned, wages, ishourly, startDate, endDate);
            Add(mom);
            Add(nanny);
            Add(child);
            Add(newContract);

        }

        public static int getDistance(String source, string dest)
        {
            var dircetionRequest = new GoogleMapsApi.Entities.Directions.Request.DirectionsRequest
            {
                TravelMode = GoogleMapsApi.Entities.Directions.Request.TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };

            var drivingDirections = GoogleMaps.Directions.Query(dircetionRequest);
            var route = drivingDirections.Routes.First();
            var leg = route.Legs.First();
            return leg.Distance.Value;
        }

        public IEnumerable<IGrouping<double, Nanny>> groupByKidsAges(bool byMax = false)
        {
            return (byMax ?
                MyDal.NannyDS.GroupBy(nanny => nanny.MaxAge, nanny => nanny)
                     :
                MyDal.NannyDS.GroupBy(nanny => nanny.MinAge, nanny => nanny));
        }

        public IEnumerable<IGrouping<int, Contract>> groupMothersBydistance(bool toSortbyMotherId = false)
        {

            List<Contract> list = getContractDS();
            if (toSortbyMotherId) // if needs to sort the grups so the group function will start on the sorted list.
            {
                list.Sort(delegate (Contract x, Contract y)
                {
                     return findMotherFromContract(x).CompareTo(findMotherFromContract(y));
                });
            }
            return list.GroupBy
                (contract =>
                getDistance(MotherWantedAddress(findMotherFromContract(contract)), findNannyFromContract(contract).Adress) // the distance between the motherwanted Address and the nannys address
                , contract => contract);
        }

        private Nanny findNannyFromContract(Contract contract)
        {
             return MyDal.FindNanny(x => x.Id == contract.NannysID);
        }

        

        public string MotherWantedAddress(Mother mom)
        {


            return (mom.AddressNearHere == null ? mom.Address : mom.AddressNearHere);

        }


    }
}
