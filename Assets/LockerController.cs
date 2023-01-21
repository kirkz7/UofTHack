using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerController : MonoBehaviour
{

    private bool playerInZone;                  //Check if the player is in the zone
    private bool lockerOpened;                    //Check if locker is currently opened or not
    public GameObject lockGameObject;            //Assign the lock gameobject here
    public bool lockOpened;
    GameObject player;
    public GameObject LockCamera;

    // Start is called before the first frame update
    void Start()
    {
        lockerOpened = false;                     //Is the locker currently opened
        lockOpened = false;
        playerInZone = false;      
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            if(!lockerOpened && !lockOpened){
                //Enable the locker script
                lockGameObject.GetComponent<MoveRuller>().enabled = true;
                //Disable the player
                player.SetActive(false);
                LockCamera.SetActive(true);
            }
        }
        
        if(lockOpened && !lockerOpened){
            lockerOpened = true;
            //Enable the player
            player.SetActive(true);
            //Disable the locker camera
            if(lockGameObject!=null){
                LockCamera.SetActive(false);
                //Disable the locker script
                lockGameObject.GetComponent<MoveRuller>().enabled = false;
            }
            this.enabled = false;
        }
    }
}
