using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Lib.models_view
{
    class ReaderView : INotifyPropertyChanged
    {
        // id читателя
        private int id;
        // фамилия
        private string firstName;
        // имя
        private string secondName;
        // отчетсво
        private string thirdName;
        // день рождения
        private DateTime birthDay;
        // город
        private string city;
        // улица
        private string street;
        // номер дома
        private int houseNumber;
        // номер квартиры
        private int flat;
        // номер телефона
        private string phoneNumber;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
                OnPropertyChanged("SecondName");
            }
        }

        public string ThirdName
        {
            get
            {
                return thirdName;
            }
            set
            {
                thirdName = value;
                OnPropertyChanged("ThirdName");
            }
        }

        public DateTime BirthDay
        {
            get
            {
                return birthDay;
            }
            set
            {
                birthDay = value;
                OnPropertyChanged("BirthDay");
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
                OnPropertyChanged("Street");
            }
        }

        public int HouseNumber
        {
            get
            {
                return houseNumber;
            }
            set
            {
                houseNumber = value;
                OnPropertyChanged("HouseNumber");
            }
        }

        public int Flat
        {
            get
            {
                return flat;
            }
            set
            {
                flat = value;
                OnPropertyChanged("Flat");
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
