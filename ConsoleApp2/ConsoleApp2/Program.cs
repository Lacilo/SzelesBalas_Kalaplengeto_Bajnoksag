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
            List<Ember> emberek = AdatB.ReadAllUsers();  
            List<Ember> sortedEmber = SortEmberList(emberek);
            
            Ui.DisplayAllEmber(sortedEmber, 3, 5);
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