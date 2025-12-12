using System;
using ConsoleApp2.Models;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            DisplayAllUsers();

        }

        // ADATBÁZIST BETÖLTŐ FÜGGVÉNY
        static List<Ember> readDB() 
        {


            return new List<Ember> { };
        }

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

        static void DisplayAllUsers()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER = localhost; DATABASE = szbk_verseny; UID = root; PASSWORD = ;";
            connection.ConnectionString = connectionString;
            connection.Open();


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

                user.IdoL = GetMin(user.Ido1, user.Ido2, user.Ido3);
                user.PontL = GetMax(user.Pont1, user.Pont2, user.Pont3);

                users.Add(user);
            }

            connection.Close();

            foreach (Ember user in users)
            {
                Console.Write(user.Id + "|");
                Console.Write(user.Nev + "|");
                Console.Write(user.Pont1 + "|");
                Console.Write(user.Pont2 + "|");
                Console.Write(user.Pont3 + "|   ");
                Console.Write(user.PontL + "|");
                Console.Write(user.IdoL);                
                Console.WriteLine();
            }
        }
    }
}