using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    class AdatB
    {
        static float GetMin(float i1, float i2, float i3)
        {
            float[] times = { i1, i2, i3 };
            float min = times[0];

            foreach (float t in times)
            {
                if (t < min)
                {
                    min = t;
                }
            }

            return min;
        }
        static int GetMax(int i1, int i2, int i3)
        {
            int[] times = { i1, i2, i3 };
            int max = times[0];

            foreach (int t in times)
            {
                if (t > max)
                {
                    max = t;
                }
            }

            return max;
        }

        private static MySqlConnection StartConnection()
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = "SERVER = localhost; DATABASE = szbk_verseny; UID = root; PASSWORD = ;";
            connection.Open();
            return connection;
        }

        public static void DeleteUser(int id)
        {
            MySqlConnection connection = StartConnection();

            string sql = "DELETE FROM versenyzok WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            connection.Close();
        }        

        public static void UpdateUserData(int id, string attr, string newValue)
        {
            MySqlConnection connection = StartConnection();

            string sql = "UPDATE versenyzok " +
                         "SET " + attr + " = @newValue " +
                         "WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@newValue", newValue);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void InsertUser(Ember ember)
        {
            MySqlConnection connection = StartConnection();

            ember.IdoL = GetMin(ember.Ido1, ember.Ido2, ember.Ido3);
            ember.PontL = GetMax(ember.Pont1, ember.Pont2, ember.Pont3);

            string sql = @"INSERT INTO " +
                         "versenyzok (Nev, Pont1, Ido1, Pont2, Ido2, Pont3, Ido3, IdoL, PontL) " +
                         "VALUES (@nev, @pont1, @ido1, @pont2, @ido2, @pont3, @ido3, @idoL, @pontL)";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@nev", ember.Nev);
            cmd.Parameters.AddWithValue("@pont1", ember.Pont1);
            cmd.Parameters.AddWithValue("@ido1", ember.Ido1);
            cmd.Parameters.AddWithValue("@pont2", ember.Pont2);
            cmd.Parameters.AddWithValue("@ido2", ember.Ido2);
            cmd.Parameters.AddWithValue("@pont3", ember.Pont3);
            cmd.Parameters.AddWithValue("@ido3", ember.Ido3);
            cmd.Parameters.AddWithValue("@idoL", ember.IdoL);
            cmd.Parameters.AddWithValue("@pontL", ember.PontL);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static List<Ember> ReadAllUsers()
        {
            MySqlConnection connection = StartConnection();


            string sql = "SELECT * FROM versenyzok";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            List<Ember> users = new List<Ember>();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Ember user = new Ember(
                    id: reader.GetInt32("Id"),
                    nev: reader.GetString("Nev"),
                    pont1: reader.GetInt32("Pont1"),
                    ido1: reader.GetFloat("Ido1"),
                    pont2: reader.GetInt32("Pont2"),
                    ido2: reader.GetFloat("Ido2"),
                    pont3: reader.GetInt32("Pont3"),
                    ido3: reader.GetFloat("Ido3"),
                    idoL: reader.GetFloat("IdoL"),
                    pontL: reader.GetInt32("PontL")
                    );

                users.Add(user);
            }

            connection.Close();

            //foreach (Ember user in users)
            //{
            //    Console.Write(user.Id + "|");
            //    Console.Write(user.Nev + "|");
            //    Console.Write(user.Pont1 + "|");
            //    Console.Write(user.Pont2 + "|");
            //    Console.Write(user.Pont3 + "|   ");
            //    Console.Write(user.PontL + "|");
            //    Console.Write(user.IdoL);
            //    Console.WriteLine();
            //}

            return users;
        }
    }
}
