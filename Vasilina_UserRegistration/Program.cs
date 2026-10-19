using System;
using PasswordHasherLibrary;
using Vasilina_UserRegistration.Model; 

namespace Vasilina_UserRegistration 
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Создание новой учетной записи для пользователя");
            Console.WriteLine();

            Console.Write("Введите имя пользователя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите фамилию пользователя: ");
            string lastName = Console.ReadLine();


            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();

            PasswordHasher hasher = new PasswordHasher();
            string salt = hasher.GenerateSalt();
            byte[] passwordHash = hasher.GetPasswordHash(password, salt);

 
            Console.WriteLine($"Хешированный пароль пользователя: {BitConverter.ToString(passwordHash).Replace("-", "")}");

            users newUser = new users
            {
                login = login,
                password_hash = passwordHash, 
                salt = salt,
                role_id = 1,       
                is_active = true,  
                created_at = DateTime.Now
            };

          
            UserRepository repository = new UserRepository();
            repository.CreateUser(newUser);

            Console.WriteLine("Учетная запись добавлена");
            Console.ReadKey();
        }
    }
}