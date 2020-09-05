using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARM_Lib.models
{
    // Моделька выдачи книг * разруливает связь Многие ко многим между читателем и книгой. Моделька бд
    [Table("book_out")]
    public class BookOut
    {
        // идентификатор выдачи
        [Key]
        public int id { get; set; }
        // книга, которую взял читатель (в бд эта вместо этого поля будет идентификатор типа int). В данном конкретном случае оперирую средствами языка
        public Book book { get; set; }
        // читатель - тот кто взял книгу (в бд опять же вместо этого поля будет идентификатор)
        public Reader reader { get; set; }
        // дата выдачи (в формате int64, т.к. в бд хранить буду timestamp)
        public Int64 dateOut { get; set; }
        // дата возврата книги (в формате int64, т.к. в бд хранить буду timestamp)
        public Int64? dateIn { get; set; }
    }
}
 