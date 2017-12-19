using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    enum E_gender { boy, girl };

    class Child
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
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int MothersId
        {
            get
            {
                return mothersId;
            }

            set
            {
                mothersId = value;
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
            this.Id = id;
            this.MothersId = mothersId;
            FName = fName;
            LName = lName;
            this.Gender = gender;
            this.SpacialNeeds = spacialNeeds;
            this.SpacialNeedsDescription = spacialNeedsDescription;
            this.Birthday = birthday;
        }

        #endregion

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
