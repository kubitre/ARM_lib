using ARM_Lib.models;
using ARM_Lib.models_view;
using System;

namespace ARM_Lib.converters
{
    class BooksDBToBooksView : ITypeConverters<Book, BookView>
    {
        public BookView convert(Book data)
        {
            return new BookView
            {
                ID = data.id,
                Name = data.name,
                AuthorName = data.authorName,
                AmountCopies = (uint)data.amountCopies,
                AmountPages = data.amountPages,
                DatePublish = DateTime.Now,
                Genre = data.genre,
                ISBN = data.isbn,
                Price = data.price,
                PublishingHouse = data.publishingHouse
            };
        }
    }
}
