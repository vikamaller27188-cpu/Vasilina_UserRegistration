using System.Linq;
using Vasilina_UserRegistration.Model; 

namespace Vasilina_UserRegistration 
{
    public class UserRepository
    {
      
        private static atelier_dbEntities _context;

        public static atelier_dbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new atelier_dbEntities();
            }
            return _context;
        }

        /// <summary>
        /// Добавляет нового пользователя в БД.
        /// </summary>
        public void CreateUser(users newUser) 
        {
            atelier_dbEntities db = GetContext();
            db.users.Add(newUser); 
            db.SaveChanges();
        }
    }
}