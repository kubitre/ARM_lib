using ARM_Lib.models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ARM_Lib.database
{
    // Data Access Object (DAO) - слой по работе с данными в бд
    class BooksDao : IDatabaseFetcher<Book>, IDataBaseMutable<Book>
    {
        private Context dbContext; // пример инкапсуляции - в данном случае контекст по работе с базой заворачиваем в private и пользуемся только из методами из этого класса
        public BooksDao()
        {
            dbContext = new Context();
        }
        public BooksDao(Context context)
        {
            dbContext = context;
        }
        // Стандартный метод по созданию строки в бд
        public bool CreateData(Book dat)
        {
            using(dbContext)
            {
                dbContext.books.Add(dat);
                dbContext.SaveChanges();
                return true;
            }
        }

        // получение определённого количества элементов с каким-то сдвигом из бд
        public List<Book> Fetch(int amount, int offset)
        {
            using (var context = new Context())
            {
                return context.books.Take(amount).ToList();
            }
        }

        // удаление
        public bool RemoveData(Book dat)
        {
            using(dbContext)
            {
                var deletedBook = dbContext.books.Find(dat.id);
                dbContext.books.Remove(deletedBook);
                dbContext.SaveChanges(); // SaveChanges - при любом раскладе делает Flush в базу, таким образом применяются изменения
                return true;
            }
        }

        public bool UpdateData(Book dat)
        {
            using(dbContext)
            {
                dbContext.books.AddOrUpdate(dat);
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}
