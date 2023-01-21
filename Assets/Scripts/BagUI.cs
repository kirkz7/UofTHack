using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public GameObject hammer;
    public GameObject key;
    public GameObject wholeBag;
    public CharacterStatus cs;
    public void sethammer(bool status)
    {
        hammer.SetActive(status);
    }
    public void setkey(bool status)
    {
        key.SetActive(status);
    }
    public void onclickhammer()
    {
        hammer.SetActive(true);
        cs.sethammer(true);
        cs.setkey(false);
        key.SetActive(false);
        wholeBag.SetActive(false);
    }
    public void onclickkey()
    {
        cs.sethammer(false);
        cs.setkey(true);
        hammer.SetActive(false);
        key.SetActive(true);
        wholeBag.SetActive(false);
        
    }
    public void onclickbag()
    {
        hammer.SetActive(false);
        key.SetActive(false);
        cs.sethammer(false);
        cs.setkey(false);
        wholeBag.SetActive(true);
        if(!cs.everhammer)
            wholeBag.transform.Find("Hammer").gameObject.SetActive(false);
        else
            wholeBag.transform.Find("Hammer").gameObject.SetActive(true);
        if(!cs.everkey)
            wholeBag.transform.Find("Key").gameObject.SetActive(false);
        else
            wholeBag.transform.Find("Key").gameObject.SetActive(true);
    }
}
