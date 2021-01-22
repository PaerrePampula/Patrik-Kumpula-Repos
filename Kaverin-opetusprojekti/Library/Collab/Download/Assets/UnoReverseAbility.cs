using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoReverseAbility : BaseAbility
{
    [SerializeField]
    GameObject unoreversecardGameObject;

    [SerializeField]
    Transform urcilmestyskohta;

    public override void CastAbility()
    {

        GameObject theCardItself = Instantiate(unoreversecardGameObject, urcilmestyskohta.position, urcilmestyskohta.transform.rotation);
        theCardItself.transform.SetParent(urcilmestyskohta);
        theCardItself.transform.localScale = new Vector3(1, 1, 1);
        Destroy(theCardItself.gameObject, abilityEffectDuration);
        timetoUse = Time.time + cooldown;
        currcdtime = Time.time;

    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
