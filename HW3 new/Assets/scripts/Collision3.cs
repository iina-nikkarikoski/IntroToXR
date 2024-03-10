using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision3 : MonoBehaviour
{
    public bool target3 = false;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet" || collision.gameObject.tag == "hands") {
            target3 = true;
        }
    }
}
