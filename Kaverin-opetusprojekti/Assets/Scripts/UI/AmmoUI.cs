using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    //Haetaan weaponcontroller, josta otetaan currentweapon
    [SerializeField]
    WeaponController weaponController;
    //Tämä haetaan weaponcontrollerin avulla, EI MANUAALISESTI
    IWeaponable targetGun;
    //Kohdease, josta haetaan ammusmäärä
    [SerializeField]
    TextMeshProUGUI targetText;
    [SerializeField]
    Image weaponImage;
    //Kohde teksti joka korvataan ammusmäärällä
    // Start is called before the first frame update
    private void Start()
    {

        //Päivitetään weapontracker tänhetkisellä aseeella (Eli poistetaan mahdollinen evenhandler ja vaihdetaan trackattava ase, sekä lisätään evenhandler uudestaan)
        updateWeaponTracker(weaponController.GetCurrentWeapon());
        //Päivitetään tämänhetkinen ui manuaalisesti ilman onEventtiä, jotta tiedot olisi aluksi oikein
        updateUI();
    }
    void OnEnable()
    {

        //OnEvent, jossa aseenvaihdossa tämä tieto päivittyy
        weaponController.onWeaponChange += updateWeaponTracker;

    }
    private void OnDisable()
    {
        targetGun.OnAmmoUpdate -= updateUI;
        //Muistetaan epätilata tapahtuma
    }
    void updateWeaponTracker(IWeaponable weaponable)
    {
        //Try...catch kokeillaan poistaa vanha event, jos se löytyy.
        //Tämä myös onnistuisi tsekkaamalla että onko tämänhetkinen targetgun null.
        try
        {
            targetGun.OnAmmoUpdate -= updateUI;
        }
        catch (NullReferenceException)
        {   
            //Jos tätä ei löydy, ei haittaa! Se voi olla näin. Jatka executea t. Pärre C# compilerille
            //HUOM. ÄLÄ KÄYTÄ catch(Exception):IA. SE OTTAA _KAIKKI_ VIRHEET JA IGNOREE NE
            //TARKENNA AINA VIRHEEN TYYPPI ESIM catch(NullReferenceException) PARAMETRIIN
            //muuten c# compiler ei välittäis ollenkaan ihan sama mikä virhe tulee, ja sit mietitään miksei tule erroria
        }


        targetGun = weaponable;
        weaponable.OnAmmoUpdate += updateUI;
        weaponImage.sprite = weaponable.WeaponImage;
    }
    void updateUI()
    {
        var allAmmo = targetGun.getAmmo(); 
        //Ns tuple on targetGun.getAmmon return value, voi siis sisältää useamman returnin
        var cAmmo = allAmmo.Item1; //Tehdään jokaisesta ammo valuesta erillinen uusi variable, jotta niitä on helpompi käsitellä
        var mAmmo = allAmmo.Item2;
        var sAmmo = allAmmo.Item3;
        targetText.text = string.Format("{0}/{1} - {2}", cAmmo, mAmmo, sAmmo);
        //Formatoidaan ammoista teksti.
    }

}
