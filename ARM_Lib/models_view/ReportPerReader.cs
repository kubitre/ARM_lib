using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ARM_Lib.models_view
{
    class ReportPerReader : INotifyPropertyChanged
    {
        // id читателя
        private int id;
        // фамилия
        private string firstName;
        // имя
        private string secondName;
        // отчетсво
        private string thirdName;
        // номер телефона
        private string phoneNumber;

        // количество книг на руках
        private int amountBooksOnHand;

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

        public int AmountBooksOnHand
        {
            get
            {
                return amountBooksOnHand;
            }
            set
            {
                amountBooksOnHand = value;
                OnPropertyChanged("AmountBooksOnHand");
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
