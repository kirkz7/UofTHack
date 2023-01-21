using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public CharacterStatus cs;
    public BagUI bui;
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
                    {
                        cs.everhammer = true;
                        cs.sethammer(true);
                        cs.setkey(false);
                        bui.sethammer(true);
                        bui.setkey(false);
                    }
                    if(hit.transform.gameObject.name == "key")
                    {
                        cs.everkey = true;
                        cs.setkey(true);
                        cs.sethammer(false);
                        bui.sethammer(false);
                        bui.setkey(true);
                    }
                }
            } 
        }
        if(Input.GetKeyDown(KeyCode.F) && cs.withhammer)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if (Physics.Raycast(ray, out hit, 2) && cs.withhammer)
            {
                if(hit.transform.gameObject.tag == "Destoryable")
                {
                    BreakableObject bo = hit.transform.gameObject.GetComponent<BreakableObject>();
                    bo.triggerBreak();
                }
            } 
        }
    }
}
