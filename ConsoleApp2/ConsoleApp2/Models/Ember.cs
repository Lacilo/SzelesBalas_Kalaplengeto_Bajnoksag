using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    class Ember
    {
        int id;
        string nev;
        int pont1;
        float ido1;
        int pont2;
        float ido2;
        int pont3;
        float ido3;
        float idoL;
        int pontL;

        public Ember(int id, string nev, int pont1, float ido1, int pont2, float ido2, int pont3, float ido3, float idoL = 0, int pontL = 0)
        {
            this.id = id;
            this.nev = nev;
            this.pont1 = pont1;
            this.ido1 = ido1;
            this.pont2 = pont2;
            this.ido2 = ido2;
            this.pont3 = pont3;
            this.ido3 = ido3;
            this.idoL = idoL;
            this.pontL = pontL;
        }

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public int Pont1 { get => pont1; set => pont1 = value; }
        public float Ido1 { get => ido1; set => ido1 = value; }
        public int Pont2 { get => pont2; set => pont2 = value; }
        public float Ido2 { get => ido2; set => ido2 = value; }
        public int Pont3 { get => pont3; set => pont3 = value; }
        public float Ido3 { get => ido3; set => ido3 = value; }
        public float IdoL { get => idoL; set => idoL = value; }
        public int PontL {  get => pontL; set => pontL = value; }
    }
}
