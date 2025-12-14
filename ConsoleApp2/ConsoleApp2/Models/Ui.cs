using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class Ui
    {
        public static void DisplayAllEmber(List<Ember> emberek, int rSor = 3, int aktivSor = 1) 
        {     
            Console.WriteLine("┌────┬──────────┬─────────────────────────┬─────────────┬─────────────┬─────────────┬──────────────┬─────────────┐");
            Console.WriteLine("│ Id │ Helyezés │ Teljes neve az embernek │ 1. Eredmény │ 2. Eredmény │ 3. Eredmény │ Legjobb pont │ Legjobb idő │");
            Console.WriteLine("├────┼──────────┼─────────────────────────┼─────────────┼─────────────┼─────────────┼──────────────┼─────────────┤");

            foreach (var ember in emberek)
            {
                // ┌────┬──────────┬─────────────────────────┬─────────────┬─────────────┬─────────────┬──────────────┬─────────────┐
                // │ Id │ Helyezés │ Teljes neve az embernek │ 1. Eredmény │ 2. Eredmény │ 3. Eredmény │ Legjobb pont │ Legjobb idő │
                // ├────┼──────────┼─────────────────────────┼─────────────┼─────────────┼─────────────┼──────────────┼─────────────┤

                

                //Console.Write("├────┼──────────┼─────────────────────────┼───────┼───────┼───────┼───────┼──────┤\n");
                Console.Write($"│ ");

                if (aktivSor + 2 == rSor)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write($"{ ember.Id}");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(5, rSor);
                Console.Write($"│    {emberek.IndexOf(ember) + 1}");
                Console.SetCursorPosition(16, rSor);
                Console.Write($"│ {ember.Nev}");
                Console.SetCursorPosition(42, rSor);
                Console.Write($"│ {ember.Pont1}p / {ember.Ido1}s");
                Console.SetCursorPosition(56, rSor);
                Console.Write($"│ {ember.Pont2}p / {ember.Ido2}s");
                Console.SetCursorPosition(70, rSor);
                Console.Write($"│ {ember.Pont3}p / {ember.Ido3}s");
                Console.SetCursorPosition(84, rSor);
                Console.Write($"│ {ember.PontL}p");
                Console.SetCursorPosition(99, rSor);
                Console.Write($"│ {ember.IdoL}s");
                Console.SetCursorPosition(113, rSor);
                Console.Write("│");

                if (emberek.Count - 1 == emberek.IndexOf(ember))
                { 
                    Console.WriteLine("\n└────┴──────────┴─────────────────────────┴─────────────┴─────────────┴─────────────┴──────────────┴─────────────┘");
                }
                else
                { 
                    Console.WriteLine("\n├────┼──────────┼─────────────────────────┼─────────────┼─────────────┼─────────────┼──────────────┼─────────────┤"); 
                }

                rSor += 2;

                //Console.Write(ember.Id + "|");
                //Console.Write(ember.Nev + "|");
                //Console.Write(ember.Pont1 + "|");
                //Console.Write(ember.Pont2 + "|");
                //Console.Write(ember.Pont3 + "|");
                //Console.Write(ember.PontL + "|");
                //Console.Write(ember.IdoL);
                //Console.WriteLine();
            }   
        }
    }
}
