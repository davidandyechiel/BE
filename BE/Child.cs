using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BE
{


    public class Child : IComparable, INotifyPropertyChanged
    {
        private int id;
        private int mothersId;
        private string fName;
        private string lName;
        private EnumClasses.E_gender gender;
        private bool spacialNeeds;
        private string spacialNeedsDescription;
        private DateTime birthday;
        #region Property

        public string FName
        {
            get
            {
                return fName;
            }

            set
            {

                fName = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FName"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LName"));
            }
        }



        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Id"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MothersId"));
            }

        }



        public EnumClasses.E_gender Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Gender"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SpacialNeeds"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SpacialNeedsDescription"));
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Birthday"));
            }
        }


        #endregion
        #region Ctor
        public Child() { }
        public Child(int momId)
        {
            mothersId = momId;
        }
        public Child(int id, int mothersId, string fName, string lName,  EnumClasses.E_gender gender, bool spacialNeeds, string spacialNeedsDescription, DateTime birthday)
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
            return string.Format ("{0} {1} ID: {2}", FName , LName , Id );
        }


        public int CompareTo(object obj)
        {
            return id.CompareTo(((Child)obj).Id);
        }

        public override bool Equals(object obj)
        {
            return (id.CompareTo(((Child)obj).Id) == 0);
        }


        public event PropertyChangedEventHandler PropertyChanged;


    }
}
