using System;

namespace Eka
{
    class Program
    {
        static void Main(string[] args)
        {
            float luku = 0;
            Console.WriteLine("Montako lukua?");
            int jakaja = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < jakaja; i++)
            {
                Console.WriteLine("Kirjoita luku");
                var uusiluku = Convert.ToInt32(Console.ReadLine());
                luku += uusiluku;
            }
            Console.WriteLine("Keskiarvo on " + luku / jakaja);
            Console.ReadKey();
        }

    }
}
