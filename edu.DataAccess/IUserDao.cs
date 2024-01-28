using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.DataAccess.Entities;

namespace edu.DataAccess
{
    public interface IUserDao
    {
       public User get(int id);
        void add(User user);
        void update(User user);
        void delete(int id);
        IList<User> getUsers();
    }
}
