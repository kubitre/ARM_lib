namespace ARM_Lib.database
{
    // инетрфейс по изменению данных
    interface IDataBaseMutable<T>
    {
        // обновление инфы об объекте в бдж
        bool UpdateData(T dat);
        // создание эдемента в бд
        bool CreateData(T dat);
        // удаление элемента из бд
        bool RemoveData(T dat);
    }
}
