using System;
using System.Collections.Generic;
using System.Text;

namespace LuokkaTehtävä
{
    public class Opettaja : Henkilö , IOpettaja //Tiedot jälleen kerran haetaan henkilöclassista, mutta 
        //tosin opettajien tarvitsee osaa huutaa, joten määritellään se täällä
    {
        public void HuudaOppilaille()
        {
            Console.WriteLine("Hiljaa!");
        }
        void KoitaOpettaaKakaroita(bool onnistuneesti)
        {
            //Something something
        }
    }
}
