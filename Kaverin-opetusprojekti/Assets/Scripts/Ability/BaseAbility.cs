using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : MonoBehaviour, IAbility
{
    /// <summary>
    /// Pohja kaikille abilityille.
    /// </summary>
    [SerializeField]
    protected float cooldown = 3f;
    protected float currcdtime = 0f;
    protected float abilityEffectDuration = 2f;
    protected float timetoUse = 0;
    public delegate void barTick(float durationRatio);
    public event barTick onBarTick;
    public virtual void UseAbility()
    {
        if(canUseAbility())
        {
            CastAbility();
        }


    }
    public virtual void CastAbility()
    {

    }
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (!canUseAbility())
        {
            onBarTick.Invoke(getRatioOfCoolDown());
        }
    }
    bool canUseAbility()
    {
        if (Time.time > timetoUse)
        {
            return true;
        }
        return false;
    }
    float getRatioOfCoolDown()
    {
        if (currcdtime != 0)
        {
            return (Time.time - currcdtime) / (timetoUse - currcdtime);
        }
        return 0;
    }
}

