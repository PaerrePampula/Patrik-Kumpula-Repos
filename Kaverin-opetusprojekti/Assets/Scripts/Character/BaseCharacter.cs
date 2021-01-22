using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Pohja yleiselle hahmolle. tiedot terveystilanteesta, ja mitä tehdä, kun hp saavuttaa nollan.
/// </summary>
public abstract class BaseCharacter : MonoBehaviour, IDamageable
{
    float Health = 100;
    float maxHealth = 100;
    public delegate void healthChange(float amount);
    public event healthChange onHealthChange;
    //Eventti kun hahmon hp on muuttunut
    public virtual void getDamaged(float damageAmount)
    {
        Health -= damageAmount;
        onHealthChange?.Invoke(Health);
        checkDeath(); //tarkistaa, että kuoleeko hahmo
    }
    void checkDeath()
    {
        if (Health <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
