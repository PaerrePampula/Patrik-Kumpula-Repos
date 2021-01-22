using System;

namespace MoiProjekti
{
    class Program
    {
        static void Main(string[] args)
        {
            Tervehtijä tervehtijä = new Tervehtijä();
            tervehtijä.Tervehdi();
            tervehtijä.Tervehdi("Moikkamoi");
            Console.WriteLine(tervehtijä.HaeTervehdys());
        }
    }
    public class Tervehtijä
    {
        string tervehdys;

        void AsetaTervehdys(string uusitervehdys)
        {
            tervehdys = uusitervehdys;
        }
        public void Tervehdi()
        {
            AsetaTervehdys("Moikka");
            Console.WriteLine(tervehdys);
        }
        public void Tervehdi(string omatervehdys)
        {
            Console.WriteLine(omatervehdys);
        }
        public string HaeTervehdys()
        {
            return tervehdys;
        }
    }
}
