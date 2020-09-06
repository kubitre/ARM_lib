using ARM_Lib.dg_actions;
using System.Collections.Generic;

namespace ARM_Lib.vm
{
    // интерфейс по применению изменений к данным
    interface IViewModelARM<T>
    {
        // выполняет непосредственные манипуляции с DAO слоем, по добавлению, удалению, изменению данных. Так же, есть специальный спислок deletedList, основная задача которого сохранить удалённые элементы, чтобы не потерялись (вновь добавленные)
        void commitChangeData(Dictionary<int, ActionTypes> keys, List<T> deletedList);
    }
}
