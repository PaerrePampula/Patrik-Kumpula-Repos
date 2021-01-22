using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Yleinen classi perinteisille Unreal Tournament/Quake/Doom-tyylisille pick upeille. (Ammuksia tai terveyttä.) Pohjan kautta luodaan muita pickuppeja muina classeina.
/// </summary>
public abstract class BasePickup : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            IWeaponable foundWeapon = coll.transform.GetComponentInChildren<WeaponController>().GetCurrentWeapon();
            PickingUp(foundWeapon);
            StartCoroutine(AmmoPackUsed());
        }
    }

    IEnumerator AmmoPackUsed()
    {
        this.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(10);
        this.enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;

    }

    protected abstract void PickingUp(IWeaponable seAse);



}
