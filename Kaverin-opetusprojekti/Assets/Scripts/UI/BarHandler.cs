using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarHandler : MonoBehaviour
{

    [SerializeField]
    Slider slider;
    [SerializeField]
    Image image;
    [SerializeField]
    Gradient gradient;


    private void Update()
    {
        image.color = gradient.Evaluate(slider.normalizedValue);
        //Joka frame vaihdetaan tämän palkin valueta, jos se muuttuu
        //HUOM, tän tarvis todnäk tehä sitten eventtinä...
        //Ei nimittäin kovin tarpeellista joka frame
        //1000 vihollista = 1000 kertaa per frame kutsuttais tätä
    }
    public void updateColor() //Tän alle tarvis tuoda ylempi sitten
    {

    }


}
