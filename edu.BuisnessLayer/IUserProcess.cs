using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.Dto;
namespace edu.BuisnessLayer
{
    public interface IUserProcess
    {
        UserDto Get(int id);
        void Add(UserDto user);
        void Update(UserDto user);
        void Delete(int id);
        IList<UserDto> GetUsers();
    }
}
