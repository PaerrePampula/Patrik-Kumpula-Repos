using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TÄLLÄ ON MYÖS INTERFACE IBULLETABLE INHERITANCEN KAUTTA
public class ExplBehaviour : BulletBehaviour
{
    CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        //Otetaan collider sitä varten että käytetään sen mittoja circlecastia tehdessä.
        CastExplosionCircle();
        //Tehdään "räjähdys"
        Destroy(gameObject, 0.5f);
        //Tuhotaan "räjähdys
    }
    void CastExplosionCircle()
    {
        //X komponentilla haetaan circlecolliderin säde
        var explosionRadius = circleCollider.bounds.extents.x;
        ContactFilter2D cf2d = new ContactFilter2D();
        //Haetaan filteri, jotta circlecastin saa tehtyä (pakollinen argumentti)
        List<RaycastHit2D> results = new List<RaycastHit2D>();
        //Tehdään valmis tyhjä lista circlecastin tuloksille
        Physics2D.CircleCast(transform.position, explosionRadius, Vector2.zero, cf2d.NoFilter(), results, 0f);
        //Tehdään cast. joka myös täyttää ylemmän results listan tuloksilla
        for (int i = 0; i < results.Count; i++)
        {
            //Käydään tää lista läpi, ja tehdään damage. False tarkoittaa dodamagen argumenttia destroyonhit
            //Ei haluta tuhota räjädystä törmäyksessä, joten tämä bool pitää olla false
            doDamage(results[i].collider, false);
        }
    }



}
