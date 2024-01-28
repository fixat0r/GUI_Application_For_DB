using edu.DataAccess.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;

namespace edu.DataAccess
{
    public class PersDao : IPersDao
    {
        private static Pers CreatePers(MySqlDataReader reader)
        {
            Pers pers = new Pers();
            pers.user_id = reader.GetInt32(reader.GetOrdinal("user_id"));
            pers.login = reader.GetString(reader.GetOrdinal("login"));
            pers.password = reader.GetString(reader.GetOrdinal("password"));
            return pers;
        }
        public Pers get(int id) {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "Select * from users where user_id = @id";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return CreatePers(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        public void add(Pers pers) {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "insert into users() values (@id,@login,@password);";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", pers.user_id);
            cmd.Parameters.AddWithValue("@login", pers.login);
            cmd.Parameters.AddWithValue("@password", pers.password);
            cmd.ExecuteNonQuery();
        }
        public void update(Pers pers) {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "update users set" +
                " login = @login," +
                " password = @password" +
                " where user_id = @id";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", pers.user_id);
            cmd.Parameters.AddWithValue("@login", pers.login);
            cmd.Parameters.AddWithValue("@password", pers.password);
            cmd.ExecuteNonQuery();
        }
        public void delete(int id) {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "delete from users where user_id = @id";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
        public IList<Pers> getPers() {
            IList<Pers> pers = new List<Pers>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            string sql = "Select * from users";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    pers.Add(CreatePers(reader));
                }
            }
            return pers;
        }
    }
}
