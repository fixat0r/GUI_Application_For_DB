using edu.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.DataAccess.Entities;


namespace edu.BuisnessLayer
{
    public class DtoConverter
    {

        public static Pers Convert(PersDto persDto)
        {
            if (persDto == null)
            {
                return null;
            }
            Pers pers = new Pers();
            pers.user_id = persDto.user_id;
            pers.login = persDto.login;
            pers.password = persDto.password;
            return pers;
        }

        public static PersDto Convert(Pers pers)
        {
            if (pers == null)
            {
                return null;
            }
            PersDto persDto = new PersDto();
            persDto.user_id = pers.user_id;
            persDto.login = pers.login;
            persDto.password = pers.password;
            return persDto;
        }

        public static IList<PersDto> Convert(IList<Pers> pers)
        {
            if (pers == null)
            {
                return null;
            }
            IList<PersDto> persDto = new List<PersDto>();
            foreach (var item in pers)
            {
                persDto.Add(Convert(item));
            }
            return persDto;
        }


        public static User Convert(UserDto userDto) {
            if (userDto == null) {
                return null;
            }
            User user = new User();
            user.user_id = userDto.user_id;
            user.phone = userDto.phone;
            user.address = userDto.address;
            user.numberPassport = userDto.numberPassport;
            user.numberSnils = userDto.numberSnils;
            user.surname = userDto.surname;
            user.name = userDto.name;
            user.middleName = userDto.middleName;
            user.email = userDto.email;
        
            return user;
        }

        public static UserDto Convert(User user) {
            if (user == null) {
                return null;
            }
            UserDto userDto = new UserDto();
            userDto.user_id = user.user_id;
            userDto.phone = user.phone;
            userDto.address = user.address;
            userDto.numberPassport = user.numberPassport;
            userDto.numberSnils = user.numberSnils;
            userDto.surname = user.surname;
            userDto.name = user.name;
            userDto.middleName = user.middleName;
            userDto.email = user.email;
            return userDto;
        }

        public static IList<UserDto> Convert(IList<User> user) {
            if (user == null) {
                return null;
            }
            IList<UserDto> userDto = new List<UserDto>();
            foreach (var item in user) { 
                userDto.Add(Convert(item));
            }
            return userDto;
        }

    }
}
