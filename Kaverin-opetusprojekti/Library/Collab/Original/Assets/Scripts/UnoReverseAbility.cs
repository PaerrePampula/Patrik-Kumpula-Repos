using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoReverseAbility : BaseAbility
{
    [SerializeField]
    GameObject unoreversecardGameObject;

    [SerializeField]
    Transform urcilmestyskohta;

    public override void UseAbility()
    {
        base.UseAbility();
        GameObject theCardItself = Instantiate(unoreversecardGameObject, urcilmestyskohta.position, urcilmestyskohta.transform.rotation);
        theCardItself.transform.SetParent(urcilmestyskohta);
        theCardItself.transform.localScale = new Vector3(1, 1, 1);
        Destroy(theCardItself.gameObject, abilityEffectDuration);
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
