using ARM_Lib.models;
using ARM_Lib.models_view;

namespace ARM_Lib.converters
{
    class ReaderToReports : ITypeConverters<Reader, ReportPerReader>
    {
        public ReportPerReader convert(Reader data)
        {
            return new ReportPerReader
            {
                ID = data.id,
                FirstName = data.firstName,
                SecondName = data.secondName,
                ThirdName = data.thirdName,
                PhoneNumber = data.phoneNumber
            };
        }
    }
}
