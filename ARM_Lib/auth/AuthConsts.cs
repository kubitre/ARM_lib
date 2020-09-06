using System.Security.Cryptography;

namespace ARM_Lib.auth
{
    // Реализует интерфейс IAuth (собственно, пример работы наследования, полиморфизма) Полиморфизм в данном случае заключаетс в том, что есть некоторый метод checkAuth, основная задача которого - проверить валидность вводимых пользователем данных: логина и пароля. В данном случае можно сделать несколько экземпляров 
    // который реализуют интерфейс IAuth, и уже работать не с конкретной реализацией метода checkAuth, а именно через инетрфейс
    class AuthConsts: IAuth
    {
        // Тут закрыл эти данные модификатором private, таким образом инкапсулировал эту инфу. Для работы с этими данными будут использованы специальные публичные getterы
        private const string userName = "Admin"; // константно заданный логин
        private const string passWord = "5f4dcc3b5aa765d61d8327deb882cf99"; // засолил пароль с использованием md5 хеширования (исходный пароль: password). Можно перехешить, берёшь сайт http://www.md5.cz/ и хешишь какой хочешь пароль
        private MD5 md5 = System.Security.Cryptography.MD5.Create();

        // Проверяем логин и пароль (если совпадают с теми значениями, что выше, аутентификация валидная и пользователя переносит на главный экран
        public bool checkAuth(string username, string password)
        {
            if (userName != username)
            {
                return false;
            }
            var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            string result = "";
            foreach (var b in hash)
            {
                result += b.ToString("x2");
            }
            return result.Equals(passWord);
        }
    }
}
