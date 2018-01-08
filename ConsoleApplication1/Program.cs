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
                /*    for (int i = 0; i < 6; i++)
                    {
                        Child child = new Child(i * i, i * i, i.ToString(), i.ToString(), E_gender.BOY, false, ":)", new DateTime(2015,12,29));
                        BL.BL_Basic.Instance.Add(child);
                    }*/

                BL.BL_Basic.Instance.Add(new Child(1 , 1, "hello" ,"kitty", E_gender.BOY, false, ":)", new DateTime(2015, 12, 29)));
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
          
           


            Console.ReadKey();

        }
    }
}
