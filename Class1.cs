using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
     public class Class1 : INotifyPropertyChanged 
    {

        //This class develop three properties Name/Surname/FullName
        //And develop Interfaze INotifyPropertyChanged

        private string name, surname, fullname;

        //Method from INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        //Created a Method to use PropertyChangedEventHandler PropertyChanged
        //This is the method is called any time the text is modified into the text box
        private void OnPropertyChanged(string property)
        {


            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }


        }

        //The properties Name/ Surname/ FullName
        public string Name
        {
            get { return name; }
            set
            {
                name = value;

                //Calling the method developed above and when Name property is changed call Method FullName  
                OnPropertyChanged("FullName");
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("FullName");

            }
        }

        public string FullName
        {
            //return the property Name and Suname together 
            get
            {
                fullname = Name + " " + Surname;
                return fullname;
            }
            set
            {
                //Display de position of the empty space in fullname
                int VCompleto = fullname.IndexOf(" ");

                //Display de position of the empty space in value
                int VName = value.IndexOf(" ");

                //First condition if fullname and VCompleto has the same number of characters
                //Second condition if name is different to value name chagen it
                if (fullname != VCompleto.ToString() || name != value.Substring(0, VName))
                {
                    name = value.Substring(0, VName);

                    OnPropertyChanged("Name");

                }


                if (VName == VCompleto)
                {


                    //TrimStart remove all the empty spaces in the begining
                    surname = value.Substring(VName, (value.Count() - VName)).TrimStart();
                    OnPropertyChanged("Surname");
                }



            }
        }


    }
}
