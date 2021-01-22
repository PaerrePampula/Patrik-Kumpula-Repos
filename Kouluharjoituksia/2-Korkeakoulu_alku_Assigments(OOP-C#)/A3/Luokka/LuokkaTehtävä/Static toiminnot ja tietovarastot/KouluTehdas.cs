using System;
using System.Collections.Generic;
using System.Text;

namespace LuokkaTehtävä
{
    public static class KouluTehdas
    {

        public static void GeneroiKoulu(int lukumäärä, Koulu koulu)
        {
            Random random = new Random();

            for (int i = 0; i < lukumäärä; i++)
            {
                IOpettaja UusiIopettaja = new Opettaja();
                Opettaja opettaja = (Opettaja)UusiIopettaja;

                opettaja.EtuNimi = NimiVarasto.EtuNimet()[random.Next(0, NimiVarasto.EtuNimet().Count)];
                opettaja.Sukunimi = NimiVarasto.SukuNimet()[random.Next(0, NimiVarasto.SukuNimet().Count)];
                koulu.KoulunOpettajat.Add(opettaja);
                //Random.Next() syntaksissa päätepistettä ei oteta huomioon, joten lista.count - 1 olisi väärin.
            }
            for (int i = 0; i < lukumäärä; i++)
            {
                IHenkilö IOppilas = new Oppilas();
                Oppilas oppilas = (Oppilas)IOppilas;

                oppilas.EtuNimi = NimiVarasto.EtuNimet()[random.Next(0, NimiVarasto.EtuNimet().Count)];
                oppilas.Sukunimi = NimiVarasto.SukuNimet()[random.Next(0, NimiVarasto.SukuNimet().Count)];

                koulu.KoulunOppilaat.Add(oppilas);
            }
            for (int i = 0; i < lukumäärä; i++)
            {
                Moduuli moduuli = new Moduuli();

                moduuli.ModuulinNimi = NimiVarasto.KouluAineet()[random.Next(0, NimiVarasto.KouluAineet().Count)];

                koulu.KoulunModuulit.Add(moduuli);
            }
            AsetteleKoulua(koulu);
        }
        static void AsetteleKoulua(Koulu koulu)
        {
            Random random = new Random();
            foreach (Moduuli moduuli in koulu.KoulunModuulit)
            {

                moduuli.LisääOpettaja(koulu.KoulunOpettajat[random.Next(0, koulu.KoulunOpettajat.Count)]);
                
                
            }
            foreach (Oppilas oppilas in koulu.KoulunOppilaat)
            {
                oppilas.LisääModuuli(koulu.KoulunModuulit[random.Next(0, koulu.KoulunModuulit.Count)]);
            }
        }
    }
}
