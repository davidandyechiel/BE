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
                //add 



                Child ch1 = BL_Basic.Instance.FindChild(x => x.Id == 1);
                Nanny nan1 = BL_Basic.Instance.FindNanny(x => x.Id == 1);
                Mother mom1 = BL_Basic.Instance.FindMother(x => x.Id == 1);
                Contract con1 = BL_Basic.Instance.FindContract(x => x.ContractNum == 10000001);

                ch1.FName = "NewKid";
                nan1.FirstName = "newNana";
                mom1.FirstName = "newMom";
                con1.Wages = 11;
                //update
                BL_Basic.Instance.Update(ch1);
                BL_Basic.Instance.Update(mom1);
                BL_Basic.Instance.Update(nan1);
                BL_Basic.Instance.Update(con1);


                // remove 
                BL_Basic.Instance.Remove(new Child(1));
                BL_Basic.Instance.Remove(new Mother(2));
                BL_Basic.Instance.Remove(new Nanny(3));
                BL_Basic.Instance.Remove(new Contract(1,1));

               






            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
          
           


            Console.ReadKey();

        }
    }
}
