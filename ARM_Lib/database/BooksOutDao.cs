using ARM_Lib.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ARM_Lib.database
{
    class BooksOutDao : IDatabaseFetcher<BookOut>, IDataBaseMutable<BookOut>
    {
        public bool CreateData(BookOut dat)
        {
            using(var dbContext = new Context())
            {
                var addedBook = dbContext.books.Find(dat.book.id);
                var addedRead = dbContext.readers.Find(dat.reader.id);
                dbContext.bookOuts.Add(new BookOut
                {
                    reader = addedRead,
                    book = addedBook,
                    dateOut = DateTime.Now.Ticks
                });
                addedBook.amountCopies -= 1;
                dbContext.books.AddOrUpdate(addedBook);
                dbContext.SaveChanges();
                return true;
            }
        }

        public List<BookOut> Fetch(int amount, int offset)
        {
            using(var dbContext = new Context())
            {
                return dbContext.bookOuts
                    .Include(p=>p.book)
                    .Include(p =>p.reader)
                    .Take(amount).ToList();
            }
        }

        public bool RemoveData(BookOut dat)
        {
            using(var dbContext = new Context())
            {
                dbContext.bookOuts.Remove(dat);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool UpdateData(BookOut dat)
        {
            using (var dbContext = new Context())
            {
                var addedBook = dbContext.books.Find(dat.book.id);
                var changedData = dbContext.bookOuts.Find(dat.id);
                changedData.dateIn = DateTime.Now.Ticks;
                dbContext.bookOuts.AddOrUpdate(changedData);
                addedBook.amountCopies += 1;
                dbContext.books.AddOrUpdate(addedBook);
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}
