using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseCharacter;

interface IDamageable //Interfacen avulla voit käyttää jonkun objektin metodia tai variablea, vaikka et tietäisi, että mitä sen kyseisen
    //Metodin sisällä edes on.
{
    void getDamaged(float damageAmount);
    event healthChange onHealthChange;
}
