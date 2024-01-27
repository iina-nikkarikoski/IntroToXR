using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform planet;
    public float speed = 10.0f;

    void Update()
    {
        planet.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
