using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public bool withhammer;
    public bool withkey;
    public bool everhammer = false;
    public bool everkey = false;
    public void sethammer(bool status)
    {
        withhammer = status;
    }
    public void setkey(bool status)
    {
        withkey = status;
    }
}
