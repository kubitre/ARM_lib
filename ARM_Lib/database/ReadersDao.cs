using ARM_Lib.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARM_Lib.database
{
    // Конкретная реализация инетрфейсов по работе с мутациями над данными + забору данных.
    class ReadersDao : IDatabaseFetcher<Reader>, IDataBaseMutable<Reader>
    {
        public bool CreateData(Reader dat)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool UpdateData(Reader dat)
        {
            throw new NotImplementedException();
        }
    }
}
