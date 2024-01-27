using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public new Light light;
    // Start is called before the first frame update
    void Start() {
        light = GetComponent<Light>();
        LoadLightColor();
    }
    
    
    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
        light.color = new Color(1, 0, 1, 1);
        }
    }

    void LoadLightColor()
    {
        float r = PlayerPrefs.GetFloat("LightColorR", 1);
        float g = PlayerPrefs.GetFloat("LightColorG", 1);
        float b = PlayerPrefs.GetFloat("LightColorB", 1);
        float a = PlayerPrefs.GetFloat("LightColorA", 1);

        light.color = new Color(r, g, b, a);
    }
}
