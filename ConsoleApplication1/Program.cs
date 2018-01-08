using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DS;
using DAL;
using BE;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 6; i++)
                {

                    //add to list
                    Child ch = new Child(i, i, "child" + i.ToString(), "child" + i.ToString(), E_gender.BOY, false, ":)", new DateTime(2015, 12, 29));
                    Nanny nan = new Nanny(i, "nanny" + i.ToString(), "nann" + i.ToString(), new DateTime(1989, 12, 29));
                    Mother mom = new Mother(i, "mom", "mom" + i.ToString(), 1231, 1235, "aaa", "bbb", 7, 3, " ", 3);
                    BL.BL_Basic.Instance.Add(ch);
                    BL.BL_Basic.Instance.Add(nan);
                    BL.BL_Basic.Instance.Add(mom);
                    BL.BL_Basic.Instance.Add(new Contract(nan, mom, ch, 12, true, DateTime.Now, DateTime.Now));
                }
                // remove 
                BL_Basic.Instance.Remove(new Child(1));
                BL_Basic.Instance.Remove(new Mother(2));
                BL_Basic.Instance.Remove(new Nanny(3));
                BL_Basic.Instance.Remove(new Contract(1,1));

                //update



                //try some functions
                BL_Basic.Instance.groupByKidsAges
                     BL_Basic.Instance.groupMothersBydistance
                     BL_Basic.Instance.nannysThatCanWorkForMe
                     BL_Basic.Instance.nannysThatCanWorkForMePlus




            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
          
           


            Console.ReadKey();

        }
    }
}
