using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOut : MonoBehaviour {
    public Transform roomPosition; 
    public Transform outsidePosition; 
    private Transform playerTransform;
    private bool InRoom = true;

    void Start() {
        playerTransform = transform; 
        SetPlayerPosition(roomPosition.position);
    }

    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            TogglePlayerLocation();
        }
    }

    void TogglePlayerLocation() {
        if (InRoom) {
            SetPlayerPosition(outsidePosition.position);
        }
        else {
            SetPlayerPosition(roomPosition.position);
        }
        InRoom = !InRoom;
    }

    void SetPlayerPosition(Vector3 newPosition) {
        playerTransform.position = newPosition;
    }
}
