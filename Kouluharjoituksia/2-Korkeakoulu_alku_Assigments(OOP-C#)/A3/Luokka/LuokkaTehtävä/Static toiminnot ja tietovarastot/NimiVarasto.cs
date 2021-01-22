using System;
using System.Collections.Generic;
using System.Text;

namespace LuokkaTehtävä
{
    public static class NimiVarasto
    {
        public static List<string> EtuNimet()
        {
            List<string> generatedlist = new List<string>
            {
                "Petri", "Markus", "Jani", "Anna", "Eero", "Make", "Kalle", "Sebastian", "Benjamin", "Jouni",
                "Laura", "Liisa", "Emilia", "Katariina","Katri","Miro","Kaapo","Bartholomeus","Alexandra",
                "Marja", "Marjatta","Olivia"
            };
            
            return generatedlist;
        }
        public static List<string> SukuNimet()
        {
            List<string> generatedlist = new List<string>
            {
                "Havumäki", "Virtanen", "Suomalainen", "Ailio", "Aho", "Puro", "Heikinheimo", "Holma", "Saarenpää",
                "Soini", "Paasivirta", "Lahdensuo", "Kulo", "Leikola", "Niinistö", "Sillanpää", "Sirola", "Virkkunen",
                "Kivelä", "Lasanen", "Hiidenheimo"
            };
            return generatedlist;
        }
        public static List<string> KouluAineet()
        {
            List<string> generatedlist = new List<string>
            {
                "Matematiikka", "Fysiikka", "Kemia", "Biologia", "Maantieto", "Englanti", "Ruotsi", "Yhteiskuntatiede"
            };
            return generatedlist;
        }
    }
}
