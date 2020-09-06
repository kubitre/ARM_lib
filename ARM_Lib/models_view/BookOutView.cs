using ARM_Lib.models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ARM_Lib.models_view
{
    // Вью моделька, то есть та моделька данных, которая по итогу используется прослойкой и непосредсвенно из которой происходит бинд на View часть
    class BookOutView: INotifyPropertyChanged
    {
        // идентификатор выдачи
        private int id;
        // книга, которую взял читатель (в бд эта вместо этого поля будет идентификатор типа int). В данном конкретном случае оперирую средствами языка
        private Book book;
        // читатель - тот кто взял книгу (в бд опять же вместо этого поля будет идентификатор)
        private Reader reader;
        // дата выдачи (в формате int64, т.к. в бд хранить буду timestamp)
        private DateTime dateOut;
        // дата возврата книги (в формате int64, т.к. в бд хранить буду timestamp)
        private DateTime? dateIn;

        // событие, которое в дальнейшем использется контекстом WPF для ререндера или прочих действий связанных с отрисовкой ui 
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

        public Book Book
        {
            get
            {
                return book;
            }
            set
            {
                book = value;
                OnPropertyChanged("Book");
            }
        }

        public Reader Reader
        {
            get
            {
                return reader;
            }
            set
            {
                reader = value;
                OnPropertyChanged("Reader");
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

        public DateTime? DateIn
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

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
