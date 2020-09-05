using ARM_Lib.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ARM_Lib.database
{
    class BooksOutDao : IDatabaseFetcher<BookOut>, IDataBaseMutable<BookOut>
    {
        public bool CreateData(BookOut dat)
        {
            throw new NotImplementedException();
        }

        public List<BookOut> Fetch(int amount, int offset)
        {
            using(var dbContext = new Context())
            {
                return dbContext.bookOuts.Include(p=>p.book).Include(p =>p.reader).Take(amount).ToList();
            }
        }

        public bool RemoveData(BookOut dat)
        {
            throw new NotImplementedException();
        }

        public bool UpdateData(BookOut dat)
        {
            throw new NotImplementedException();
        }
    }
}
