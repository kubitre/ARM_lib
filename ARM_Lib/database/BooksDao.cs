using ARM_Lib.models;
using System.Collections.Generic;
using System.Linq;

namespace ARM_Lib.database
{
    class BooksDao : IDatabaseFetcher<Book>, IDataBaseMutable<Book>
    {
        private Context dbContext;
        public BooksDao()
        {
            dbContext = new Context();
        }
        public BooksDao(Context context)
        {
            dbContext = context;
        }
        public bool CreateData(Book dat)
        {
            using(dbContext)
            {
                dbContext.books.Add(dat);
                dbContext.SaveChanges();
                return true;
            }
        }

        public List<Book> Fetch(int amount, int offset)
        {
            using (var context = new Context())
            {
                return context.books.Take(amount).ToList();
            }
        }

        public bool RemoveData(Book dat)
        {
            using(dbContext)
            {
                dbContext.books.Remove(dbContext.books.Find(dat));
                return true;
            }
        }

        public bool UpdateData(Book dat)
        {
            return false;
        }
    }
}
