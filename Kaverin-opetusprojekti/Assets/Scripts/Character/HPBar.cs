using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Pelaajan tai jonkun muun objektin hp-palkin toiminnallisuus.
/// </summary>
public class HPBar : MonoBehaviour
{
    [SerializeField]
    BaseCharacter targetCharacter;
    [SerializeField]
    IDamageable target;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        target = (IDamageable)targetCharacter;
        target.onHealthChange += updateHP;
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        target.onHealthChange -= updateHP;
    }

    void updateHP(float newAmount)
    {
        slider.value = newAmount;
    }
}
