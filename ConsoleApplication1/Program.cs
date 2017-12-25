using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DS;
using DAL;
using BE;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 6; i++)
                {
                    Child child = new Child(i * i, i * i, i.ToString(), i.ToString(), E_gender.boy, false, ":)", new DateTime());
                    BL.BL_Basic.Instance.Add(child);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
          
            


            Console.ReadKey();

        }
    }
}
