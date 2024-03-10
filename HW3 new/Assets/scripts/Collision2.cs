using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision2 : MonoBehaviour
{
    public bool target2 = false;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet" || collision.gameObject.tag == "hands") {
            target2 = true;
        }
    }
}
