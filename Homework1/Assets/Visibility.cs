using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingLensVisibility : MonoBehaviour
{
    public Camera magnifyingLensCamera;

    void Update()
    {
        if (magnifyingLensCamera.enabled)
        {
            // Make the object visible when looking through the magnifying lens.
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            // Hide the object when not looking through the magnifying lens.
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}