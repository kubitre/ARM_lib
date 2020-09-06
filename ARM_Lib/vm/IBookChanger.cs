using System.Collections;

namespace ARM_Lib.vm
{
    // интерфейс декларирующий выдачу\забор книги читателю
    interface IBookChanger
    {
        // выдача книги (по выбранному списку)
        bool LendingBook(IList booksSelected);
        // забор книг (по выбранному списку)
        bool ReturnBook(IList booksSelected);
    }
}
