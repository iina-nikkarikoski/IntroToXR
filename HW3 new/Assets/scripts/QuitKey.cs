using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class QuitKey : MonoBehaviour
{
    public InputActionReference action;

    private void OnEnable()
    {
        action.action.Enable();
        action.action.performed += OnQuitPerformed;
    }

    private void OnDisable()
    {
        action.action.Disable();
        action.action.performed -= OnQuitPerformed;
    }

    private void OnQuitPerformed(InputAction.CallbackContext context)
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
