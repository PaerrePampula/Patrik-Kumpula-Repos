using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : BasePickup
{
    protected override void PickingUp(IWeaponable seAse)
    {
        seAse.SetAmmo();
    }
}
