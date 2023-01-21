using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject hammer;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if (Physics.Raycast(ray, out hit, 1))
            {
                if(hit.transform.gameObject.tag == "Collectable")
                {
                    hit.transform.gameObject.SetActive(false);
                    if(hit.transform.gameObject.name == "hammer")
                        SpwanHammer();
                }
            } 
        }
    }
    void SpwanHammer()
    {

    }
}
