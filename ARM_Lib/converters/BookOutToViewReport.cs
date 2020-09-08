using ARM_Lib.models;
using ARM_Lib.models_view;
using System;

namespace ARM_Lib.converters
{
    class BookOutToViewReport : ITypeConverters<BookOut, ReportOutView>
    {
        public ReportOutView convert(BookOut data)
        {
            var converterReader = new ReadersDbToSimplereaders();
            return new ReportOutView
            {
                ID = data.id,
                AmountPages = data.book.amountPages,
                AuthorName = data.book.authorName,
                DateIn = DateTime.FromBinary(data.dateIn ?? 0),
                DateOut = DateTime.FromBinary(data.dateOut),
                SimpleReaderView = converterReader.convert(data.reader),
                DatePublish = DateTime.FromBinary(Convert.ToInt64(data.book.datePublish)),
                Genre = data.book.genre,
                Name = data.book.name,
                PublishingHouse = data.book.publishingHouse
            };
        }
    }
}
