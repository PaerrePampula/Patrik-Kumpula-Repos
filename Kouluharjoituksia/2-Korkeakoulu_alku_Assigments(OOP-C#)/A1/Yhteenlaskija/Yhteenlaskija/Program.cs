using System;

namespace Yhteenlaskija
{
    class Program
    {
        public string valinta;
        public void Lasku(int valittu)
        {
            Console.WriteLine("\n"); //selkolukuisuuden vuoksi
            int a; //luvut a ja b jolle suoritetaan laskutoimitus
            int b;
            Console.WriteLine("Kirjoita luku");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kirjoita toinen luku");
            b = Convert.ToInt32(Console.ReadLine());
            if (valittu == 1) //valinnan perusteella päätetään että onko nyt summa vai erotus. valinta valitaan alempana switch statementissa
            {
                Console.WriteLine(string.Format("Summa luvuille on {1} + {2} = {0}", a + b, a, b ));
            }
            else
            {
                Console.WriteLine(string.Format("Erotus luvuille on {1} - {2} = {0}", a - b, a, b));
            }
            Console.WriteLine("\n"); //selkolukuisuutta varten
            Switcher(); //palataan takaisin switch statementiin, jotta laskinta voi käyttää useammin kuin kerran .
        }
        public void Switcher()
        {
            Console.WriteLine("Valitse laskutoimitus numerolla\n1 = Yhteenlasku \n2 =  Vähennyslasku \nNumerolla 0 poistutaan");
            valinta = Console.ReadLine();
            while (valinta != "0")
            {
                switch (valinta)
                {
                    case "1":
                        Console.WriteLine("Valittu toiminto on summa");
                        Lasku(Convert.ToInt32(valinta));
                        break;
                    case "2":
                        Console.WriteLine("Valittu toiminto on erotus");
                        Lasku(Convert.ToInt32(valinta));
                        break;
                    default:
                        Console.WriteLine("Tuntematon komento! \n");
                        Switcher();
                        break;
                }
            }
        }
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Switcher();
        }

    }
}
