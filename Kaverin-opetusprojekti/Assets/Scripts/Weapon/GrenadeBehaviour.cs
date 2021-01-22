using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour, IBulletAble
{
    private float damage;

    public float Damage { get => damage; set => damage = value; }

    public void setDamage(float amount)
    {
        damage = amount;
    }
    [SerializeField]
    GameObject explosionPrefab;
    //Tämä setataan luotia instantiatetessa
    IEnumerator waitWhileAndExplode()
    {
        yield return new WaitForSeconds(2);
        DoExplosion();
    }
    private void Start()
    {
        StartCoroutine(waitWhileAndExplode());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoExplosion();
    }
    void DoExplosion()
    {
        GameObject explosionClone = Instantiate(explosionPrefab, transform.position, transform.rotation);
        IBulletAble bulletAble = (IBulletAble) explosionClone.GetComponent(typeof(IBulletAble));
        bulletAble.setDamage(damage);
        Destroy(gameObject);
    }
}
