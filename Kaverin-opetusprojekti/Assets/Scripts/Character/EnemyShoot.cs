using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Erittäin pelkistetty vihollisen ampuminen. Luotu vain demonstroimaan uno-abilityn käyttöä
/// </summary>
public class EnemyShoot : BaseWeapon
{
    float reloadtime = 2f;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {



        while (true)
        {
            fireGun();
            yield return new WaitForSeconds(reloadtime);
        }

    }

}
