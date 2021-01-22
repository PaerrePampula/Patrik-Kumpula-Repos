using System;

namespace LuokkaTehtävä
{
    class Program
    {
        static void Main(string[] args)
        {
            Toiminta(); //Aloitetaan toiminta, miksei suoraan mainissa? Toiminta() on näppärä looppi ohjelman toiminnalle
        }
        static void Toiminta()
        {
            Koulu koulu = new Koulu(); //Tarvitaan ensiksi koulu, johon saadaan melko näppärästi lopulta sidottua kaikki objektit...
            KouluTehdas.GeneroiKoulu(2, koulu); //Tarvitaan se koulun sisältö, eli oppilaat, opettajat ja moduulit.
            koulu.PrinttaaKoulu(); //Lopuksi me tehdään pitkä string jonka konsoli tulostaa...
            Console.WriteLine("Tee uusi koulu enterillä! \n \n \n \n");
            Console.ReadKey();
            Toiminta(); //...ja jatketaan random arvoilla koulujen tekemistä!
        }
    }
}
