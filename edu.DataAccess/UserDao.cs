using edu.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Tutorial.SqlConn;
using System.Data.Common;

namespace edu.DataAccess
{
    public class UserDao : IUserDao
    {
        private static User CreateUser(MySqlDataReader reader)
        { 
            User user = new User();
            user.user_id = reader.GetInt32(reader.GetOrdinal("user_id"));
            user.phone = reader.GetString(reader.GetOrdinal("phone"));
            user.address = reader.GetString(reader.GetOrdinal("address"));
            user.numberPassport = reader.GetString(reader.GetOrdinal("number_passport"));
            user.numberSnils = reader.GetString(reader.GetOrdinal("number_snils"));
            user.surname = reader.GetString(reader.GetOrdinal("surname"));
            user.name = reader.GetString(reader.GetOrdinal("name"));
            user.middleName = reader.GetString(reader.GetOrdinal("middle_name"));
            user.email = reader.GetString(reader.GetOrdinal("email"));
            return user;
        }
        public User get(int id) 
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "Select * from Personal_data where user_id = @id";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader reader = cmd.ExecuteReader()) {
                if (!reader.Read())
                {
                    return CreateUser(reader);
                }
                else {
                    return null;
                }
            }
        }
        public void add(User user) 
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "insert into personal_data() values (@id,@phone,@address,@number_passport,@number_snils,@surname,@name,@middle_name,@email);";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", user.user_id);
            cmd.Parameters.AddWithValue("@phone", user.phone);
            cmd.Parameters.AddWithValue("@address",user.address);
            cmd.Parameters.AddWithValue("@number_passport", user.numberPassport);
            cmd.Parameters.AddWithValue("@number_snils", user.numberSnils);
            cmd.Parameters.AddWithValue("@surname", user.surname);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@middle_name", user.middleName);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.ExecuteNonQuery();
        }
        public void update(User user)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "update personal_data set" +
                " phone = @phone," +
                " address = @address," +
                " number_passport = @number_passport," +
                " number_snils = @number_snils," +
                " surname = @surname," +
                " name = @name," +
                " middle_name = @middle_name," +
                " email = @email" +
                " where user_id = @id";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", user.user_id);
            cmd.Parameters.AddWithValue("@phone", user.phone);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@number_passport", user.numberPassport);
            cmd.Parameters.AddWithValue("@number_snils", user.numberSnils);
            cmd.Parameters.AddWithValue("@surname", user.surname);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@middle_name", user.middleName);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.ExecuteNonQuery();
        }
        public void delete(int id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "delete from personal_data where user_id = @id";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
        public IList<User> getUsers()
        {
            IList<User> user = new List<User>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "Select * from Personal_data";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) {
                    user.Add(CreateUser(reader));
                }
            }
            return user;
        }
    }
}
