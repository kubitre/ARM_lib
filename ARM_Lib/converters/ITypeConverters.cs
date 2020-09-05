using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Lib.converters
{
    // Интерфейс конвертера типов (своего рода переводчик моделей из типа, которые хранятся в бд, в типы, которые отображаются по итогу)
    interface ITypeConverters<TypeFrom, TypeTo>
    {
        TypeTo convert(TypeFrom data);
    }
}
