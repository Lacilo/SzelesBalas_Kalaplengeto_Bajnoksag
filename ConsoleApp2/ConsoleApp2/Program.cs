using System;
using ConsoleApp2.Models;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ember> emberek = AdatB.ReadAllUsers();
            int sor = 0;
            
            Ui.DisplayAllEmber(emberek, 3, sor * 2);

            ConsoleKeyInfo keyInfo;

            while (true)
            {
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        sor -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        sor += 1;
                        break;
                    case ConsoleKey.A:
                        Console.Write("Vesszővel (,) elválasztva adja meg a játékos adatait --> ");

                        string inpNew = Console.ReadLine();
                        string[] adat = inpNew.Split(',');

                        Ember ujEmber = new Ember(int.Parse(adat[0]), adat[1], int.Parse(adat[2]), int.Parse(adat[3]), int.Parse(adat[4]), int.Parse(adat[5]), int.Parse(adat[6]), int.Parse(adat[7]), int.Parse(adat[8]));
                        AdatB.InsertUser(ujEmber);

                        emberek = AdatB.ReadAllUsers();
                        break;
                    case ConsoleKey.E:
                        Console.Write("Adja meg a módosítani kívánt adat nevét és az új értékét vesszővel (,) elválasztva --> ");
                        string inpEdit = Console.ReadLine();
                        string[] data = inpEdit.Split(',');

                        AdatB.UpdateUserData(emberek[sor].Id, data[0], data[1]);
                        emberek = AdatB.ReadAllUsers();
                        break;
                    case ConsoleKey.D:
                        AdatB.DeleteUser(emberek[sor].Id);
                        sor = 0;
                        emberek = AdatB.ReadAllUsers();
                        break;
                }

                Ui.DisplayAllEmber(emberek, 3, sor * 2);

                Console.WriteLine("a: Hozzáadás, e: Szerkesztés, d: Törlés");

                //Console.WriteLine(sor);
                //Console.WriteLine(emberek[sor].Id);
            }
        }

        static Ember FindMaxEmber(List<Ember> emberek)
        {
            Ember MaxEmber = emberek[0];

            foreach (Ember ember in emberek)
            {
                if (ember.PontL > MaxEmber.PontL)
                {
                    MaxEmber = ember;
                }
                else if (ember.PontL == MaxEmber.PontL && ember.IdoL < MaxEmber.IdoL)
                {
                    MaxEmber = ember;
                }                
            }

            return MaxEmber;
        }
        static List<Ember> SortEmberList(List<Ember> emberek)
        {
            List<Ember> sortedEmber = new List<Ember> { };

            while (emberek.Count > 0)
            {
                Ember jMaxEmber = FindMaxEmber(emberek);

                sortedEmber.Add(jMaxEmber);
                emberek.Remove(jMaxEmber);
            }

            return sortedEmber;
        }
    }
}