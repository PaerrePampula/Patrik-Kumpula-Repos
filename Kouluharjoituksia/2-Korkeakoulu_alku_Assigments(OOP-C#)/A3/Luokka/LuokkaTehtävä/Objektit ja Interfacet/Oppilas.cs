using System;
using System.Collections.Generic;
using System.Text;

namespace LuokkaTehtävä
{
    public class Oppilas : Henkilö //Tiedot haetaan abstract henkilöclassista
    {
        public List<Moduuli> moduulit = new List<Moduuli>();

        public void LisääModuuli(Moduuli moduuli)
        {
            moduulit.Add(moduuli);
        }

    }
}
