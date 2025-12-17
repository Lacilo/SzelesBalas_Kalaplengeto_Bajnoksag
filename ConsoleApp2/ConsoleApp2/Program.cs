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
            List<Ember> emberek = SortEmberList(AdatB.ReadAllUsers());
            int sor = 0;
            int sorDisp = 0;
            int sorStart = 0;
            int lapSzam = (int) Math.Ceiling(emberek.Count / 10.0);
            int jLap = 1;
            int lap = 0;            
            
            Ui.DisplayAllEmber(emberek, 0, 3, sorDisp);
            Console.WriteLine($"a: Hozzáadás, e: Szerkesztés, d: Törlés, w: kiírás a weboldalra, s: Weboldal indítása, f: Adatok frissítése | {jLap} / {lapSzam}");

            ConsoleKeyInfo keyInfo;

            while (true)
            {
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        sor -= 1;
                        sorDisp -= 2;
                        break;
                    case ConsoleKey.DownArrow:
                        sor += 1;
                        sorDisp += 2;
                        break;
                    case ConsoleKey.A:
                        emberek = ReadNewUserData();
                        AdatB.WriteToHtml();
                        break;
                    case ConsoleKey.E:
                        emberek = UpdateUserData(emberek, sor);
                        AdatB.WriteToHtml();
                        break;
                    case ConsoleKey.D:
                        AdatB.DeleteUser(emberek[sor].Id);
                        sor = 0;
                        sorDisp = 0;
                        emberek = SortEmberList(AdatB.ReadAllUsers());
                        lap = 0;
                        jLap = 1;
                        sorStart = 0;
                        AdatB.WriteToHtml();
                        break;
                    case ConsoleKey.W:
                        AdatB.WriteToHtml();
                        break;
                    case ConsoleKey.S:
                        Process.Start(new ProcessStartInfo 
                        { 
                            FileName = @"..\..\..\..\..\web\index.html",
                            UseShellExecute = true
                        });
                        break;
                    case ConsoleKey.RightArrow:
                        if (!(jLap + 1 > lapSzam))
                        {
                            lap += 10;
                            jLap++;
                            sorStart += 10;
                            sor = sorStart;
                            sorDisp = 0;
                        }

                        break;
                    case ConsoleKey.LeftArrow:
                        if (!(jLap - 1 == 0))
                        {
                            lap -= 10;
                            jLap--;
                            sorStart -= 10;
                            sor = sorStart;
                            sorDisp = 0;
                        }
                        
                        break;
                    case ConsoleKey.F:
                        emberek = SortEmberList(AdatB.ReadAllUsers());
                        break;
                }

                lapSzam = (int)Math.Ceiling(emberek.Count / 10.0);

                Ui.DisplayAllEmber(emberek, lap, 3, sorDisp);

                Console.WriteLine($"a: Hozzáadás, e: Szerkesztés, d: Törlés, w: kiírás a weboldalra, s: Weboldal indítása, f: Adatok frissítése | {jLap} / {lapSzam}");

                //Console.WriteLine("megjelenítendő sor: " + sorDisp + "\n");
                //Console.WriteLine("valódi sor: " + sor);
                //Console.WriteLine("kiválaszott ember id:" + emberek[sor].Id);
            }
        }

        private static List<Ember> ReadNewUserData()
        {
            List<Ember> emberek;
            Console.Write("Pontosvesszővel (;) elválasztva adja meg a játékos adatait\nId;Név;1.pont;1.idő;2.pont;2.idő;3.pont;3.ido --> ");

            string inpNew = Console.ReadLine();
            string[] adat = inpNew.Split(';');

            Ember ujEmber = new Ember(int.Parse(adat[0]), adat[1], int.Parse(adat[2]), float.Parse(adat[3]), int.Parse(adat[4]), float.Parse(adat[5]), int.Parse(adat[6]), float.Parse(adat[7]));
            AdatB.InsertUser(ujEmber);
            emberek = SortEmberList(AdatB.ReadAllUsers());

            return emberek;
        }

        private static List<Ember> UpdateUserData(List<Ember> emberek, int sor)
        {
            //Console.Write("Válassza ki fel le nyilakkal a módosítandó adatot - Név --> ");
            //string inpEdit = Console.ReadLine();
            //string[] data = inpEdit.Split(',');

            string[,] attribList = new string[10, 2]
            {
                {"Id", "Id" },
                {"Név", "Nev" },
                {"1. pontszám", "Pont1" },
                {"1. idő", "Ido1" },
                {"2. pontszám", "Pont2" },
                {"2. idő", "Ido2" },
                {"3. pontszám", "Pont3" },
                {"3. idő", "Ido3" },
                {"Legjobb idő", "IdoL" },
                {"Legjobb pontszám", "PontL" }                
            };

            string inpEdit = "";
            string attrib = "";

            int attribIndex = 0;

            ConsoleKeyInfo keyInfo;

            Console.SetCursorPosition(0, 24);
            Console.Write($"Válassza ki fel le nyilakkal a módosítandó adatot - {attribList[attribIndex, 0]} --> ");

            while (inpEdit == "")
            {
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        attribIndex -= 1;
                        if (attribIndex < 0) attribIndex = 9;
                        break;
                    case ConsoleKey.DownArrow:
                        attribIndex += 1;
                        if (attribIndex > 9) attribIndex = 0;
                        break;
                    case ConsoleKey.Enter:
                        Console.Write($"Válassza ki fel le nyilakkal a módosítandó adatot - {attribList[attribIndex, 0]} --> ");
                        inpEdit = Console.ReadLine();
                        break;
                }
                Console.SetCursorPosition(52, 24);
                Console.Write("                                ");
                Console.SetCursorPosition(52, 24);
                Console.Write($"{attribList[attribIndex, 0]} --> ");
            }

            AdatB.UpdateUserData(emberek[sor].Id, attribList[attribIndex, 1], inpEdit, emberek[sor]);
            emberek = SortEmberList(AdatB.ReadAllUsers());

            return emberek;
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