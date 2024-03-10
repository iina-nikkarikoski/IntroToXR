using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision5 : MonoBehaviour
{
    public bool target5 = false;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet" ) {
            target5 = true;
        }
    }
}
