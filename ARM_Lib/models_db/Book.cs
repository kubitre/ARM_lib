using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARM_Lib.models
{
    // Моделька книги * всё по той таблице из документика (моделька, которая по итогу в бд хранится).
    [Table("books")]
    public class Book
    {
        // шифр книги
        [Key]
        public int id { get; set; }
        // автор
        public string authorName { get; set; }
        // название книги
        public string name { get; set; }
        // жанр
        public string genre { get; set; }
        // год издания
        public string datePublish { get; set; }
        // издательство
        public string publishingHouse { get; set; }
        // количество страниц
        public int amountPages { get; set; }
        // isbn
        public string isbn { get; set; }
        // цена (сделал даблом, т.к. цена может быть не строго целой)
        public double price { get; set; }
        // количество книг в наличии
        public int amountCopies { get; set; }

        public Book(string name)
        {
            this.name = name;
        }

        public Book() { }

        public override string ToString()
        {
            return name + ", " + authorName + ", " + publishingHouse;
        }
    }
}
