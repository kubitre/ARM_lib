using ARM_Lib.models;
using ARM_Lib.models_view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Lib.converters
{
    class BookOutViewToDb : ITypeConverters<BookOutView, BookOut>
    {
        public BookOut convert(BookOutView data)
        {
            return new BookOut
            {
                id = data.ID,
                book = data.Book,
                reader = data.Reader,
                dateOut = data.DateOut.Ticks,
                dateIn = data.DateIn.Value.Ticks
            };
        }
    }
}
