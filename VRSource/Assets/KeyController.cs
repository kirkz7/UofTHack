using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public bool Toggleable;
    public bool picked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Plane")
            Toggleable = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Toggleable = false;
    }
}
