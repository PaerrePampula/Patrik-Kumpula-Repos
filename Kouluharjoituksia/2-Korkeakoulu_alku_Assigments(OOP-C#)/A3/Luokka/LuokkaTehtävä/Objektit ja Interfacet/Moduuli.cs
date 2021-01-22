using System;
using System.Collections.Generic;
using System.Text;

namespace LuokkaTehtävä
{
    public class Moduuli
    {
        public string ModuulinNimi { get; set; }

        public List<Opettaja> opettajat = new List<Opettaja>();
        public Moduuli()
        {
        }

        public void LisääOpettaja(Opettaja opettaja)
        {
            opettajat.Add(opettaja);
        }
        public string Tulosta()
        {
            return ModuulinNimi;
        }
    }
}
