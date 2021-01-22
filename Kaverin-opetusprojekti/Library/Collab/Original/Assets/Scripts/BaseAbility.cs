using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : MonoBehaviour, IAbility
{
    float cooldown = 3f;
    float currcdtime = 0f;
    protected float abilityEffectDuration = 2f;

    public virtual void UseAbility()
    {
        if(cooldown > currcdtime)
        {
            return;
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

