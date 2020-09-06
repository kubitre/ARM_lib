using ARM_Lib.models;
using ARM_Lib.models_view;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ARM_Lib.database
{
    // Конкретная реализация инетрфейсов по работе с мутациями над данными + забору данных.
    class ReadersDao : IDatabaseFetcher<Reader>, IDataBaseMutable<Reader>
    {
        public bool CreateData(Reader dat)
        {
            using(var dbContext = new Context())
            {
                dbContext.readers.Add(dat);
                dbContext.SaveChanges();
                return true;
            }
        }

        public List<Reader> Fetch(int amount, int offset)
        {
            using(var dbContext = new Context())
            {
                return dbContext.readers.ToList();
            }
        }

        public bool RemoveData(Reader dat)
        {
            using(var dbContext = new Context())
            {
                dbContext.readers.Remove(dbContext.readers.Find(dat.id));
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool UpdateData(Reader dat)
        {
            using(var dbContext = new Context())
            {
                dbContext.readers.AddOrUpdate(dat);
                dbContext.SaveChanges();
                return true;
            }
        }

        public Reader ConvertSimpleToFull(SimpleReaderView readerView)
        {
            using(var dbContext = new Context())
            {
                var reader = new Reader
                {
                    id = readerView.ID
                };
                return dbContext.readers.Find(reader.id);
            }
        }
    }
}
