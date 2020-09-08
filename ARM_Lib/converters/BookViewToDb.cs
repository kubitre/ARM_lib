using ARM_Lib.models;
using ARM_Lib.models_view;

namespace ARM_Lib.converters
{
    class BookViewToDb : ITypeConverters<BookView, Book>
    {
        public Book convert(BookView data)
        {
            return new Book
            {
                id = data.ID,
                amountCopies = (int)data.AmountCopies,
                datePublish = data.DatePublish.Ticks.ToString(),
                amountPages = data.AmountPages,
                authorName = data.AuthorName,
                genre = data.Genre,
                isbn = data.ISBN,
                name = data.Name,
                price = data.Price,
                publishingHouse = data.PublishingHouse
            };
        }
    }
}
