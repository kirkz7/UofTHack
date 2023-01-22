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
    GameObject fpln;
    GameObject fpmn;
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        lockerOpened = false;                     //Is the locker currently opened
        lockOpened = false;
        playerInZone = false;      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInZone = true;
            player = other.gameObject;
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
                camera = player.GetComponentInChildren<Camera>().gameObject;
                fpln = player.GetComponentInChildren<FirstPersonLookNew>().gameObject;
                fpln.SetActive(false);
                fpmn = player.GetComponent<FirstPersonMovementNew>().gameObject;
                fpmn.SetActive(false);
                camera.SetActive(false);
                LockCamera.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && playerInZone)
        {
            if(!lockerOpened && !lockOpened){
            camera.SetActive(true);
            fpln.SetActive(true);
            fpmn.SetActive(true);
            LockCamera.SetActive(false);     
            //Disable the locker camera
            if(lockGameObject!=null){
                LockCamera.SetActive(false);
                //Disable the locker script
                lockGameObject.GetComponent<MoveRuller>().enabled = false;
            }
            }
        }
        
        if(lockOpened && !lockerOpened){
            lockerOpened = true;
            //Enable the player
            camera.SetActive(true);
            fpln.SetActive(true);
            fpmn.SetActive(true);
            LockCamera.SetActive(false);     
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
