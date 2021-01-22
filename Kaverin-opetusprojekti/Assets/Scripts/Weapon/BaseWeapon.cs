using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{

    //Äänilähde
    [SerializeField]
    private AudioSource source;

    private void Start()
    {
        //Attach that äänilähde shit
        source = GetComponent<AudioSource>();
    }

    //Abstract class == ei voida instantioida tätä classia, ei voida luoda objektia jolla olisi suoraan tämä classi
    //Tämän classin voi kuitenkin inherittaa käyttöön.
    [SerializeField]
    GameObject bulletPrefab;
    //Assetti josta luodaan luoti ammuttavaksi
    [SerializeField]
    Transform barrelTransform;
    //Sijainti, josta luoti lähtee liikkeelle
    [SerializeField]
    float bulletSpeed = 10f;
    [SerializeField]
    float bulletDmg = 10f;
    [SerializeField]
    bool destroyableBullet = true;

    //Protected = ei voi hakea muualta koodista tätä metodia PAITSI jos inherittaat tämän classin.
    //Virtual = voi olla korvattavissa overridella
    //Esim jokaisella objektilla C#:issa on defaulttina virtualiksi merkitty metodi: toString()
    //sen saa korvattua
    /*ESIMERKKI TOSTRING() KORVAUKSESTA:
    /*
    Class Henkilö
    {

     string etunimi;
     string sukunimi;
     
     public override void toString()
        {
            return etunimi + sukunimi;
        }
    }
    */
    protected virtual void fireGun()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, barrelTransform.position, barrelTransform.rotation);
        //Instantiatee luotiobjektin barrelpositioniin samalla resetoiden luodin rotaation.
        bulletClone.GetComponent<Rigidbody2D>().velocity = barrelTransform.transform.TransformDirection(Vector2.right * bulletSpeed);
        //Vaihtaa luodin nopeudeksi vektorin = suuntanuolen, joka on aseen piipun suuntainen sekä 10 unityn default unitin mittainen (10m?)
        IBulletAble bulletAble = (IBulletAble)bulletClone.GetComponent(typeof(IBulletAble));
        bulletAble.setDamage(bulletDmg);
        //Lisää luodulle luodille damagen
        if (destroyableBullet)
        {
            Destroy(bulletClone, 5f);
        }

        //Tuhoo luodin 5s päästä.

        //Start 1 more shooting sound
        StartCoroutine("BämBäm");
    }


    //Uutta Bämbämii
    IEnumerator BämBäm()
    {
        //Uus instanssi äänestä
        AudioSource _audio = Instantiate(source);
        //Play dat shit
        _audio.Play();
        //Wait for it to play till end then adios
        yield return new WaitForSeconds(1.802f);
    }

}
