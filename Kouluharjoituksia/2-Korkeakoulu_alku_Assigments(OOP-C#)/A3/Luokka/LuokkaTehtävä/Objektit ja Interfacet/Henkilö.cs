using System;
using System.Collections.Generic;
using System.Text;

namespace LuokkaTehtävä
{
    public class Henkilö : IHenkilö //Henkilö class luo pohjan opettajien ja oppilaiden luonnille.
    {
        public string EtuNimi { get; set; }
        public string Sukunimi { get; set; }

        public string Tulosta()
        {
            return $"{EtuNimi} {Sukunimi}";
        }
    }
}
