using ARM_Lib.models;
using ARM_Lib.models_view;

namespace ARM_Lib.converters
{
    class ReaderViewToDb : ITypeConverters<ReaderView, Reader>
    {
        public Reader convert(ReaderView data)
        {
            return new Reader
            {
                id = data.ID,
                birthDay = data.BirthDay.Ticks,
                city = data.City,
                firstName = data.FirstName,
                flat = data.Flat,
                houseNumber = data.HouseNumber,
                phoneNumber = data.PhoneNumber,
                secondName = data.SecondName,
                street = data.Street,
                thirdName = data.ThirdName
            };
        }
    }
}
