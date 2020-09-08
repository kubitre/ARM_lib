using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Lib.models_view
{
    class ReportOutView : INotifyPropertyChanged
    {
        // шифр книги
        private int id;
        // автор
        private string authorName;
        // название книги
        private string name;
        // жанр
        private string genre;
        // год издания
        private DateTime datePublish;
        // издательство
        private string publishingHouse;
        // количество страниц
        private int amountPages;
        // взял
        private DateTime dateOut;
        // вернул
        private DateTime dateIn;
        // кто взял
        private SimpleReaderView readerView;
        public ReportOutView() { }
        public ReportOutView(string name)
        {
            this.name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public string AuthorName
        {
            get
            {
                return authorName;
            }
            set
            {
                authorName = value;
                OnPropertyChanged("AuthorName");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
                OnPropertyChanged("Genre");
            }
        }

        public DateTime DatePublish
        {
            get
            {
                return datePublish;
            }
            set
            {
                datePublish = value;
                OnPropertyChanged("DatePublish");
            }
        }

        public string PublishingHouse
        {
            get
            {
                return publishingHouse;
            }
            set
            {
                publishingHouse = value;
                OnPropertyChanged("PublishingHouse");
            }
        }

        public int AmountPages
        {
            get
            {
                return amountPages;
            }
            set
            {
                amountPages = value;
                OnPropertyChanged("AmountPages");
            }
        }

        public DateTime DateIn
        {
            get
            {
                return dateIn;
            }
            set
            {
                dateIn = value;
                OnPropertyChanged("DateIn");
            }
        }

        public DateTime DateOut
        {
            get
            {
                return dateOut;
            }
            set
            {
                dateOut = value;
                OnPropertyChanged("DateOut");
            }
        }

        public SimpleReaderView SimpleReaderView
        {
            get
            {
                return readerView;
            }
            set
            {
                readerView = value;
                OnPropertyChanged("SimpleReaderView");
            }
        }
       
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
