using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Triggeri UNO-kortille, joka kääntää vihollisen ampuman luodin 180 ympäri, kun se törmää kys. triggeriin.
/// </summary>
public class NoUTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D itjustknowstheone)
    {
        if (itjustknowstheone.CompareTag("Bullet"))
        {
            itjustknowstheone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.right) * 10;
            
        }
    }


}
