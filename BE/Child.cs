﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
  

    public class Child : IComparable
    {
        private int id;
        private int mothersId;
        private string fName;
        private string lName;
        private E_gender gender; // I added this for WPF desine
        private bool spacialNeeds;
        private string spacialNeedsDescription;
        private DateTime birthday;
        #region Property
        public  int Id
        {
            get
            {
                return id;
            }
        }

        public int MothersId
        {
            get
            {
                return mothersId;
            }

        }

        public string FName
        {
            get
            {
                return fName;
            }

            set
            {
                fName = value;
            }
        }

        public string LName
        {
            get
            {
                return lName;
            }

            set
            {
                lName = value;
            }
        }

        internal E_gender Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public bool SpacialNeeds
        {
            get
            {
                return spacialNeeds;
            }

            set
            {
                spacialNeeds = value;
            }
        }

        public string SpacialNeedsDescription
        {
            get
            {
                return spacialNeedsDescription;
            }

            set
            {
                spacialNeedsDescription = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }
        #endregion
        #region Ctor
        public Child() { }
        public Child(int id, int mothersId, string fName, string lName, E_gender gender, bool spacialNeeds, string spacialNeedsDescription, DateTime birthday)
        {
            this.id = id;
            this.mothersId = mothersId;
            FName = fName;
            LName = lName;
            this.Gender = gender;
            this.SpacialNeeds = spacialNeeds;
            this.SpacialNeedsDescription = spacialNeedsDescription;
            this.Birthday = birthday;
        }
        public Child(int id )
        {
            this.id = id;
        }
        public Child(Child child)
        {
            this.id = child.Id;
            this.mothersId = child.MothersId;
            FName = child.FName;
            LName = child.LName;
            this.Gender = child.Gender;
            this.SpacialNeeds = child.SpacialNeeds;
            this.SpacialNeedsDescription = child.SpacialNeedsDescription;
            this.Birthday = child.Birthday;
        }

        #endregion

        public override string ToString()
        {
            return "Child: " + FName + LName + "ID: " + Id + "\n";
        }

        public int CompareTo(object obj)
        {
            return id.CompareTo(((Child)obj).Id);
        }

        public override bool Equals(object obj)
        {
            return (id.CompareTo(((Child)obj).Id) == 0);
        }


    }
}
