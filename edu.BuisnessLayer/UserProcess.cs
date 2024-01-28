using edu.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.DataAccess;

namespace edu.BuisnessLayer
{
    public class UserProcess : IUserProcess
    {
        private readonly IUserDao userDao;
        public UserProcess() { 
            userDao = DaoFactory.getUserDao();

        }
       public UserDto Get(int id) {
            return DtoConverter.Convert(userDao.get(id));
        }
        public void Add(UserDto user) {
            userDao.add(DtoConverter.Convert(user));
        }
        public void Update(UserDto user) {
            userDao.update(DtoConverter.Convert(user));
        }
        public void Delete(int id) { 
            userDao.delete(id);
        }
        public IList<UserDto> GetUsers() {
          return  DtoConverter.Convert(userDao.getUsers());
        }
    }
}
