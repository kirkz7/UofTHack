using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenDoor : MonoBehaviour
{
    public InputActionReference toggleReference = null;
    DoorController dc;

    private void Awake()
    {
        toggleReference.action.started += Toggle;
        dc = gameObject.GetComponentInChildren<DoorController>();
    }

    private void OnDestory()
    {
        toggleReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        dc.tryOpen();
    }
}
