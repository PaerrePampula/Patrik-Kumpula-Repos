using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour, IBulletAble
{

    private float damage;

    public float Damage { get => damage; set => damage = value; }

    public void setDamage(float amount)
    {
        damage = amount;
    }
    //Tämä setataan luotia instantiatetessa


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        doDamage(collision);

    }
    public virtual void doDamage(Collider2D collision, bool destroyOnHit = true)
    {
        IDamageable damageComp = (IDamageable)collision.gameObject.GetComponent(typeof(IDamageable));
        //Jos luoti törmää objektiin, jolla on IDamageable interface, niin se damagetaan, jos mahdollista.

        if (damageComp != null) //Tämä siis tapahtuu, vain ja ainoastaan jos komponetti löytyy
        {
            damageComp.getDamaged(Damage);

        }

        NoUTrigger noU = collision.GetComponent<NoUTrigger>();
        //Destroyonhit == Eli siis jos parametri joka on defaultisti true niin luoti tuhoutuu myös törmäyksessä.
        //Tämä sitä varten että koska explbehaviour on myös "luoti" niin se ei tuhoudu heti törmäyksessä
        if ((!noU) && (!collision.CompareTag("Bullet")) && destroyOnHit == true)
        {
            //Luoti tuhotaan sen jälkeen.
            Destroy(gameObject);
        }
    }
}
