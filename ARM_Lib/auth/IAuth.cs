using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Lib.auth
{
    // Для демонстрации ООП, ввёл эту штуку, её наследует единственный экземплярп AuthConsts (в идеале, можно как варик сказать, что здесь точка расширения и можно прикрутить ту же аутентификацию (именно аутентификацию) через бд, к примеру)
    interface IAuth
    {
        // единственный метод для проверки подлинности вводимых пользователем данных 
        bool checkAuth(string userName, string password); 
    }
}
