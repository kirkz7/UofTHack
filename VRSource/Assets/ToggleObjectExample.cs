using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleObjectExample : MonoBehaviour
{
    public InputActionReference toggleReference = null;
    KeyController kc;
    public DoorController dc;
    private void Awake()
    {
        toggleReference.action.started += Toggle;
        kc = gameObject.GetComponent<KeyController>();
    }

    private void OnDestory()
    {
        toggleReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        if (kc.Toggleable)
        {
            gameObject.SetActive(false);
            dc.gotKey = true;
        }
    }
}
