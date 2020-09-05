using ARM_Lib.models;
using ARM_Lib.models_view;
using System;

namespace ARM_Lib.converters
{
    // Тут в целом вообще вопросов не должно быть, просто формальнавя реализапция интерфейса, где просто в соответсвие ставится два множества
    class ReaderDbToReaderView : ITypeConverters<Reader, ReaderView>
    {
        public ReaderView convert(Reader data)
        {
            return new ReaderView {
                ID = data.id,
                FirstName = data.firstName,
                SecondName = data.secondName,
                ThirdName = data.thirdName,
                BirthDay = DateTime.FromBinary(data.birthDay), // здесь лучше заставить пользователя всегда вводить =) а иначе исключения будут 
                City = data.city,
                Flat = data.flat,
                HouseNumber = data.houseNumber,
                PhoneNumber = data.phoneNumber,
                Street = data.street
            };
        }
    }
}
