using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        // calculate angle to rotate
        Vector3 orbVector = Camera.main.WorldToScreenPoint(transform.position);
        orbVector = Input.mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

        // rotate the object according to calculated angle
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}