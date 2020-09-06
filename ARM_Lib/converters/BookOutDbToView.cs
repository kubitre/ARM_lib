using ARM_Lib.models;
using ARM_Lib.models_view;
using System;

namespace ARM_Lib.converters
{
    // конвертер из типа BookOut в тип BookOutView
    class BookOutDbToView : ITypeConverters<BookOut, BookOutView>
    {
        public BookOutView convert(BookOut data)
        {
            return new BookOutView
            {
                ID = data.id,
                DateIn = DateTime.FromBinary(data.dateIn ?? 0) ,
                DateOut = DateTime.FromBinary(data.dateOut),
                Book = data.book,
                Reader = data.reader
            };
        }
    }
}
