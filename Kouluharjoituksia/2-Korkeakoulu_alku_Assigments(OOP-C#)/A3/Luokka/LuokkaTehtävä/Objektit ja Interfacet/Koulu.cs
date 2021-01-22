using System;
using System.Collections.Generic;
using System.Text;

namespace LuokkaTehtävä
{
    public class Koulu
    {
        public List<Opettaja> KoulunOpettajat = new List<Opettaja>();
        public List<Oppilas> KoulunOppilaat = new List<Oppilas>();
        public List<Moduuli> KoulunModuulit = new List<Moduuli>(); 
        //Talletan tänne kaikki luodut objektit helppokäyttöisyyttä varten esim foreach loopeissa tai LINQ searcheissa
        public void PrinttaaKoulu()
        {
            Console.WriteLine(FormatoituKoulunSisältö());
        }
        string FormatoituKoulunSisältö() //Tämä "näppärän" näköinen sekamelska on se koko teksti jonka ohjelma lopulta printtaa
            //toki sitä olisi voinut pilkkoa useampaankin stringiin jotka sitten concacenatetaan yhteen mutta ohjelma on tosin hyvin yksinkertainen.
        {
            string palautettava = "Koulussa on seuraavia asioita: ";
            palautettava += $"{ KoulunOpettajat.Count } opettajaa { KoulunOppilaat.Count } oppilasta sekä { KoulunModuulit.Count } moduulia.";
            foreach (Opettaja opettaja in KoulunOpettajat)
            {
                palautettava += $"\nOpettaja { opettaja.Tulosta() }";
            }
            foreach (Oppilas oppilas in KoulunOppilaat)
            {
                palautettava += $"\nOppilas { oppilas.Tulosta() }";
                foreach (Moduuli moduuli in oppilas.moduulit)
                {
                    palautettava += $"\n{ oppilas.Tulosta()} opiskelee tällä hetkellä moduulia { moduuli.Tulosta() }";
                }
            }
            palautettava += "\n\nModuuleita ovat seuraavat";
            foreach (Moduuli moduuli in KoulunModuulit)
            {
                palautettava += $"\n    { moduuli.Tulosta() }, moduulia opettaa";
                foreach (Opettaja opettaja in moduuli.opettajat)
                {
                   palautettava += $" { opettaja.Tulosta() }";
                }

            }
            return palautettava;
        }
    }
}
