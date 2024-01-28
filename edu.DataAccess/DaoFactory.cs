using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.DataAccess
{
    public class DaoFactory
    {
        public static IUserDao getUserDao() 
        {
            return new UserDao();    
        }
        public static IPersDao getPersDao() { 
            return new PersDao();
        }
    }
}
