using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARM_Lib.models
{
    // Читатель. Моделька бд
    [Table("readers")]
    public class Reader
    {
        // id читателя
        [Key]
        public int id { get; set; }
        // фамилия
        public string firstName { get; set; }
        // имя
        public string secondName { get; set; }
        // отчетсво
        public string thirdName { get; set; }
        // день рождения
        public Int64 birthDay { get; set; }
        // город
        public string city { get; set; }
        // улица
        public string street { get; set; }
        // номер дома
        public int houseNumber { get; set; }
        // номер квартиры
        public int flat { get; set; }
        // номер телефона
        public string phoneNumber { get; set; }

        public override string ToString()
        {
            return firstName + " " + secondName;
        }
    }
}
