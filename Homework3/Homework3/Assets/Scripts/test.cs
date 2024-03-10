using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class test : MonoBehaviour
{
    private Vector2 movementSpeed;
    ActionBasedController controller;

    private void Update()
    {
    Vector2 joystickInput = controller.selectAction.action.ReadValue<Vector2>();
    Debug.Log($"Joystick Input: {joystickInput}");

    Vector3 moveDirection = new Vector3(joystickInput.x, 0f, joystickInput.y).normalized;
    Debug.Log($"Move Direction: {moveDirection}");

    transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
    }
}
