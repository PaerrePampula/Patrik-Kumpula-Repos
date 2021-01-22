using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : BaseWeapon, IWeaponable
{
    [SerializeField]
    WeaponController parent; //Skripti jossa kontrolloidaan aseita.

    public delegate void Fire();
    public event Fire OnAmmoUpdate;

    int currAmmo = 9; //Lipas ammukset juuri nyt

    [SerializeField]
    int maxAmmo = 9; //max lipas ammukset
    [SerializeField]
    int surplusAmmo = 32; //Muut kuin lippaassa olevat ammukset.
    [SerializeField]
    float reloadtime = 1f;

    bool reloading = false;

    public Sprite WeaponImage { get { return GetComponent<SpriteRenderer>().sprite; } }

    public int GetCurrAmmo()
    {
        return currAmmo;
    }

    public void SetCurrAmmo(int value)
    {
        currAmmo = value;
        OnAmmoUpdate?.Invoke();
    }

    public int GetSurplusAmmo()
    {
        return surplusAmmo;
    }

    public void SetSurplusAmmo(int value)
    {
        surplusAmmo = value;
        OnAmmoUpdate?.Invoke();
    }




    void OnDisable()
    {
        parent.OnFireClick -= checkFireGun;
    }
    void OnEnable()
    {
        parent.OnFireClick += checkFireGun;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.R)) && (GetCurrAmmo() != maxAmmo) && (reloading == false)) //Voit ladata r:ää painaessa ainoastaan jos et lataa ja lipas ei ole täysi
        {
            reload();
        }
    }
    protected override void fireGun() //Protected, koska alkuperäinen metodi on myös protected. Pakko olla overridetessa, jos alkuperäinenkin on
    {
        base.fireGun(); //base. hakee sen inheritatun metodin ja ajaa sen.
        Debug.Log(GetCurrAmmo()); //Ja sen perään voi lisätä uutta näin.
        SetCurrAmmo(GetCurrAmmo() - 1);

    }
    void reload()
    {

        var newBullets = maxAmmo; //Otetaan valmiiksi niin monta luotia, kun täydessä lippaassa on
        if (GetSurplusAmmo() > 0)
        {
            if (GetSurplusAmmo() < maxAmmo) //...mutta jos ei saada oikeista ammuksistamme tarpeeksi luoteja, otetaan vaan ne mitä on.
            {
                newBullets = GetSurplusAmmo();
            }
            StartCoroutine(reloadAction(newBullets)); //... ja siirretään ne aseen lippaalle reloadissa.

        }

    }
    void checkFireGun()
    {
        switch (GetCurrAmmo() > 0 && reloading == false) //Jos on ammuksia lippassa. Ammu
        {
            case true:
                fireGun();
                break;
            case false:
                if (reloading == false)
                {
                    reload();
                }
                break;

        }
    }
    IEnumerator reloadAction(int ammosToReload)
    {
        reloading = true;
        yield return new WaitForSeconds(reloadtime);
        SetCurrAmmo(ammosToReload);
        SetSurplusAmmo(GetSurplusAmmo() - ammosToReload);
        reloading = false;


    }
    public (int, int, int) getAmmo()
    {
        return (GetCurrAmmo(), maxAmmo, GetSurplusAmmo());
    }

    public (int, int) GetAmmo()
    {
        return (GetCurrAmmo(), GetSurplusAmmo());
    }

    public void SetAmmo()
    {
        SetSurplusAmmo(32);
        SetCurrAmmo(maxAmmo);
    }

    public GameObject GetGameObject()
    {
        return transform.gameObject;
    }
}
