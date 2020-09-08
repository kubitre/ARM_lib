
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
                var resultList = new Dictionary<int, ReportPerBooks>();
                var books = dbContext.books;
                var converter = new BookOutToReports();
                foreach (var book in books)
                {
                    var allBookOut = data.Where(it => it.book.id == book.id && it.dateIn == null).ToList();
                    var convertedResult = converter.convert(book);
                    if (resultList.ContainsKey(convertedResult.ID))
                    {
                        resultList[convertedResult.ID].AmountBooksPerHand += allBookOut.Count;
                    } else
                    {
                        convertedResult.AmountBooksPerHand = allBookOut.Count;
                        resultList.Add(convertedResult.ID, convertedResult);
                    }
                }
                return resultList.Values.ToList();
            }
        }

        public List<ReportPerReader> ReportPerReaders()
        {
            using(var dbContext = new Context())
            {
                var data = dbContext.bookOuts.Include(it => it.reader).ToList();
                var readers = dbContext.readers;
                var resultList = new Dictionary<int, ReportPerReader>();
                var converter = new ReaderToReports();
                foreach(var reader in readers)
                {
                    var allBooksPerReader = data.Where(it => it.reader.id == reader.id && it.dateIn == null).ToList();

                    var convertedResult = converter.convert(reader);
                    if (resultList.ContainsKey(convertedResult.ID))
                    {
                        resultList[convertedResult.ID].AmountBooksOnHand += allBooksPerReader.Count;
                    } else
                    {
                        convertedResult.AmountBooksOnHand = allBooksPerReader.Count;
                        resultList.Add(convertedResult.ID, convertedResult);
                    }
                }
                return resultList.Values.ToList();
            }
        }
    }
}
