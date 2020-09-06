
using ARM_Lib.converters;
using ARM_Lib.models_view;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ARM_Lib.database
{
    // DAO по агрегации статистики, которая используется в отчётах
    class StatsDao
    {
        public ReportPerBooks ReportPerBook(int idBook)
        {
            using (var dbContext = new Context())
            {
                var converter = new BookOutToReports();
                var data = dbContext.bookOuts.Include(it => it.book).Include(it => it.reader).Where(it => it.book.id == idBook).ToList();
                var convertedStat = converter.convert(data[0].book);
                convertedStat.AmountBooksPerHand = data.Count;
                return convertedStat;
            }
        }

        public List<ReportPerBooks> ReportPerBooks()
        {
            using(var dbContext = new Context())
            {
                var data = dbContext.bookOuts.Include(it => it.book).ToList();
                var resultList = new List<ReportPerBooks>();
                var converter = new BookOutToReports();
                foreach (var bookOut in data)
                {
                    var allBookOut = data.Where(it => it.book.id == bookOut.book.id && it.dateIn == null).ToList();
                    var convertedResult = converter.convert(bookOut.book);
                    convertedResult.AmountBooksPerHand = allBookOut.Count;
                    resultList.Add(
                        convertedResult
                        );
                }
                return resultList;
            }
        }

        public List<ReportPerReader> ReportPerReaders()
        {
            using(var dbContext = new Context())
            {
                var data = dbContext.bookOuts.Include(it => it.reader).ToList();
                var resultList = new List<ReportPerReader>();
                var converter = new ReaderToReports();
                foreach(var bookOut in data)
                {
                    var allBooksPerReader = data.Where(it => it.reader.id == bookOut.reader.id && it.dateIn == null).ToList();
                    var convertedResult = converter.convert(bookOut.reader);
                    convertedResult.AmountBooksOnHand = allBooksPerReader.Count;
                    resultList.Add(convertedResult);
                }
                return resultList;
            }
        }
    }
}
