using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public delegate void WeaponChange(IWeaponable weapon);
    public event WeaponChange onWeaponChange;
    public delegate void NewWeapon();
    public event NewWeapon onNewWeapon;
    List<IWeaponable> weapons = new List<IWeaponable>();
    IWeaponable currWeapon;




    private void CheckScroll()
    {
        var mouseWheelDir = Input.GetAxis("Mouse ScrollWheel");
        WeaponSwitch(mouseWheelDir);
    }

    private void WeaponSwitch(float mouseWheelDir)
    {
        var currentWeaponIndex = weapons.IndexOf(currWeapon);

        switch (mouseWheelDir > 0)
        {
            case true:
                currentWeaponIndex++;
                currentWeaponIndex = (currentWeaponIndex >= weapons.Count) ? 0 : currentWeaponIndex;
                CurrWeapon = weapons[currentWeaponIndex];
                break;
            case false:
                break;
            default:
                break;
        }
    }

    public IWeaponable CurrWeapon
    {
        get
        {
            return currWeapon;
        }

        set
        {

            if (currWeapon != null)
            {
                currWeapon.GetGameObject().SetActive(false);
            }
            
            currWeapon = value;
            currWeapon.GetGameObject().SetActive(true);
            onWeaponChange?.Invoke(value);
            Debug.Log(currWeapon.GetGameObject());
        }
    }

    public List<IWeaponable> GetWeapons()
    {
        return weapons;
    }
    public void SetWeapons()
    {
        var childrenofPivotCount = transform.childCount;
        for (int i = 0; i < childrenofPivotCount; i++)
        {
            IWeaponable newWeapon = (IWeaponable)transform.GetChild(i).GetComponent(typeof(IWeaponable));
            if (newWeapon != null && !weapons.Contains(newWeapon))
            {
                weapons.Add(newWeapon);
            }

        }
        onNewWeapon?.Invoke();
    }


    public delegate void GunFire();
    public event GunFire OnFireClick;
    // Start is called before the first frame update
    void Start()
    {
        CurrWeapon = (IWeaponable)transform.GetChild(0).GetComponent(typeof(IWeaponable));
        GetWeapons();
        SetWeapons();
        weapons.ForEach(we => Debug.Log(we));
    }

    // Update is called once per frame

    private void Update()
    {
        CheckScroll();
    }

    void LateUpdate()
    {

        rotateHandPivot();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnFireClick?.Invoke(); //Ammu, jos on ase millä ampua
        }
    }
    void rotateHandPivot() //Kääntää siis aseen kohti hiiren sijaintia
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public IWeaponable GetCurrentWeapon()
    {
        return CurrWeapon;
    }

}
