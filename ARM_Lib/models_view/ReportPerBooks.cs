using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Lib.models_view
{
    class ReportPerBooks : INotifyPropertyChanged
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
        // isbn
        private string isbn;
        // цена (сделал даблом, т.к. цена может быть не строго целой)
        private double price;
        // количество книг в наличии
        private UInt32 amountCopies;

        // количество книг на руках
        private int amountBooksPerHands;

        public ReportPerBooks() { }
        public ReportPerBooks(string name)
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

        public string ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
                OnPropertyChanged("ISBN");
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public UInt32 AmountCopies
        {
            get
            {
                return amountCopies;
            }

            set
            {
                amountCopies = value;
                OnPropertyChanged("AmountCopies");
            }
        }

        public int AmountBooksPerHand
        {
            get
            {
                return amountBooksPerHands;
            }
            set
            {
                amountBooksPerHands = value;
                OnPropertyChanged("AmountBooksPerHand");
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
