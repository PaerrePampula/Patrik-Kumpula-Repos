using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Palkki, josta näkee visuaalisesti sen, että milloin joku ability on taas valmiina käyttöön
/// </summary>
public class CoolDownBar : MonoBehaviour
{ 
    [SerializeField]
    BaseAbility ability;
    [SerializeField]
    TextMeshProUGUI textPercentage;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    private void OnEnable()
    {
        ability.onBarTick += updateBar;
    }
    private void OnDisable()
    {
        ability.onBarTick -= updateBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateBar(float value)
    {
        slider.value = value * 100;
        textPercentage.text = Mathf.RoundToInt(value * 100).ToString() + "%";
    }
}
