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
            List<Ember> embers = AdatB.ReadAllUsers();
            int sor = 0;
            
            Ui.DisplayAllEmber(embers, 3, sor * 2);

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
                        break;
                    case ConsoleKey.E:
                        break;
                    case ConsoleKey.D:
                        AdatB.DeleteUser(embers[sor].Id);
                        sor = 0;
                        embers = AdatB.ReadAllUsers();
                        break;
                }

                Ui.DisplayAllEmber(embers, 3, sor * 2);

                Console.WriteLine("a: Hozzáadás, e: Szerkesztés, d: törlés");


                //Console.WriteLine(sor);
                //Console.WriteLine(embers[sor].Id);
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