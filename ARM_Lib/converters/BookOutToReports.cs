using ARM_Lib.models;
using ARM_Lib.models_view;
using System;

namespace ARM_Lib.converters
{
    class BookOutToReports : ITypeConverters<Book, ReportPerBooks>
    {
        public ReportPerBooks convert(Book data)
        {
            return new ReportPerBooks
            {
                ID = data.id,
                Name = data.name,
                AmountCopies = (uint)data.amountCopies,
                AmountPages = data.amountPages,
                ISBN = data.isbn,
                DatePublish = DateTime.Now,
                AuthorName = data.authorName,
                Genre = data.genre,
                Price = data.price,
                PublishingHouse = data.publishingHouse
            };
        }
    }
}
