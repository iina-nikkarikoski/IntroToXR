using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision4 : MonoBehaviour
{
    public bool target4 = false;

    void OnCollisionEnter(Collision collision)
    {      
        if(collision.gameObject.tag == "bullet" || collision.gameObject.tag == "hands") {
            target4 = true;
        }
    }
}
