using ARM_Lib.models;
using ARM_Lib.models_view;
using System;

namespace ARM_Lib.converters
{
    class ReadersDbToSimplereaders : ITypeConverters<Reader, SimpleReaderView>
    {
        public SimpleReaderView convert(Reader data)
        {
            return new SimpleReaderView
            {
                ID = data.id,
                Name = data.firstName + " " + data.secondName
            };
        }
    }
}
