﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class ExtentionMethodes
    {


        public static DateTime DoubleToDateTime(double d)
        {
            int H = (int)d;
            int m = (int)(d - H);
            string str = string.Format("{0}:{1}", (H < 100 ? "0" + (H / 10).ToString() : (H / 10).ToString()), (m < 5 ? "00" : "30")); // set string in format HH:mm
            return DateTime.ParseExact(str, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static bool  CompareTo(this DateTime[][] table, DateTime[,] otherTable)
        {
            for (int i = 0; i < 6; i++)
            { //if   nannys start is later than mother start , nannys end is earlier than mother end  then return false   
                if (table[i][0] > otherTable[i, 0] || (table[i][1] < otherTable[i, 1]))
                    return false;
            }
            return true;
        }


        public static DateTime[][] setDefaulteTable(this DateTime[][] table, double[] fromTable)
        {
            table = new DateTime[6][];
            for (int i = 0; i < fromTable.Length; i += 2)
            {
                table[i / 2] = new DateTime[2];
                table[i / 2][ 0] = DoubleToDateTime(fromTable[i]);
                table[i / 2][ 1] = DoubleToDateTime(fromTable[i + 1]);
            }
            return table;
        }
        public static DateTime[][] setDefaulteTable(this DateTime[][] table)
        {
            table = new DateTime[6][];
            for (int i = 0; i < 12; i += 2)
            {
                table[i / 2] = new DateTime[2];
                table[i / 2][ 0] = DateTime.ParseExact("07:00", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                table[i / 2][ 1] = DateTime.ParseExact("16:30", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }
            return table;
        }
        public static DateTime[][] setDefaulteTable(this DateTime[][] table, DateTime[][] fromTable)
        {
            table = new DateTime[6][ ];
            for (int i = 0; i < 12; i += 2)
            {
                table[i / 2] = new DateTime[2];
                table[i / 2][ 0] = fromTable[i / 2][ 0];
                table[i / 2][ 1] = fromTable[i / 2][ 1];
            }
            return table;
        }



        public static DateTime[,] setDefaulteTable( this DateTime[,] table, double[] fromTable)
        {
            table = new DateTime[6, 2];
            for (int i = 0; i < fromTable.Length; i += 2)
            {
                table[i / 2, 0] = DoubleToDateTime(fromTable[i]);
                table[i / 2, 1] = DoubleToDateTime(fromTable[i + 1]);
            }
            return table;
        }
        public static DateTime[,] setDefaulteTable(this DateTime[,] table)
        {
            table = new DateTime[6, 2];
            for (int i = 0; i < 12; i += 2)
            {
                table[i / 2, 0] = DateTime.ParseExact("07:00", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                table[i / 2, 1] = DateTime.ParseExact("16:30", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }
            return table;
        }
        public static DateTime[,] setDefaulteTable(this DateTime[,] table, DateTime[,] fromTable)
        {
            table = new DateTime[6, 2];
            for (int i = 0; i < 12; i += 2)
            {
                table[i / 2, 0] = fromTable[i / 2, 0];
                table[i / 2, 1] = fromTable[i / 2, 1];
            }
            return table;
        }

        public static bool[] Parse(this bool[] table, string str)
        {
            bool[] output = table;
            int i = 0;
            string[] strArr = str.Split(',', ';');
            foreach (string s in strArr)
                output[i] = BoolIt(s);
            return output;
        }

        private static bool BoolIt(string str)
        {
            if (str == "true")
                return true;
            else return false;
        }


        public static DateTime[][] Parse(this DateTime[][] table, string str)
        {
            DateTime[][] output = table;
            int i = 0;
            string[] strArr = str.Split(';');
            foreach (string s in strArr)
            {
                table[i] = new DateTime[2];
                table[i] = DateIt(strArr[i]);
            }
                
            return output;
        }

        private static DateTime[] DateIt(string str)
        {
            string[] strArr = str.Split(';');
            DateTime[] t = new DateTime[2];
            t[0] = DateTime.ParseExact(strArr[0], "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            t[1] = DateTime.ParseExact(strArr[1], "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            return t;
        }

        


    }
}