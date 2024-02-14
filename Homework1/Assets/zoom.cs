using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondCamera;
    public float followSpeed = 5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            FollowMainCamera();
        }
    }

    void FollowMainCamera()
    {
        if (mainCamera != null && secondCamera != null)
        {
            transform.position = Vector3.Lerp(transform.position, mainCamera.transform.position, followSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, mainCamera.transform.rotation, followSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogError("Main Camera or Second Camera not assigned!");
        }
    }
}
