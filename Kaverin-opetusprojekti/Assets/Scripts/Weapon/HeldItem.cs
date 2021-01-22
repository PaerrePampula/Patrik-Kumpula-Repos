using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItem : MonoBehaviour
{
    float objectRotRight = 0;
    float objectRotLeft = -180;
    Transform parentTransform;
    Quaternion objectAngle;
    Quaternion parentAngle;
    void itemRotation()
    {
        objectAngle = transform.localRotation;
        parentAngle = parentTransform.localRotation;

        transform.localEulerAngles = (parentAngle.w > 0.5f) ? 
            new Vector3(objectRotRight , objectAngle.y, objectAngle.z) : 
            new Vector3(objectRotLeft,objectAngle.y, objectAngle.z);

    }
    private void Update()
    {
        itemRotation();
    }
    void Start()
    {
        parentTransform = transform.parent.GetComponent<Transform>();

    }
}
