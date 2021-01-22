using System;
using System.Collections.Generic;
using System.Text;

namespace LuokkaTehtävä
{
    interface IHenkilö
    {
        public string EtuNimi { get; set; }
        public string Sukunimi { get; set; }
        string Tulosta();
    }
}
