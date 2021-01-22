using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GunScript;


public interface IWeaponable
{
    (int, int) GetAmmo();
    (int, int,int) getAmmo();
    event Fire OnAmmoUpdate;
    void SetAmmo();

    GameObject GetGameObject();
    Sprite WeaponImage { get; }
}
