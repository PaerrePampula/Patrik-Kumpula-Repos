using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    List<IAbility> abilityList = new List<IAbility>();
    [SerializeField]
    List<Transform> abilitiesListing = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < abilitiesListing.Count; i++)
        {
            abilityList.Add((IAbility)abilitiesListing[i].gameObject.GetComponent(typeof (IAbility)));
        }
        abilityList.ForEach(ability => Debug.Log(ability));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilityList[0].UseAbility();
        }

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    abilityList[1].UseAbility();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    abilityList[2].UseAbility();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    abilityList[3].UseAbility();
        //}
    }


}
