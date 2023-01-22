// Script by Marcelli Michele

using System.Linq;
using UnityEngine;
using System.Collections;
using Photon.Pun;

public class PadLockPassword : MonoBehaviour
{
    MoveRuller _moveRull;

    public int[] _numberPassword = {0,0,0,0};
    private bool _alreadyUnlocked = false;

    [SerializeField] private Animator _lockerAnimator;
    [SerializeField] private Animator _doorAnimator;

    private void Awake()
    {
        _moveRull = FindObjectOfType<MoveRuller>();
    }

    public void Password()
    {
        if (_moveRull._numberArray.SequenceEqual(_numberPassword) && !_alreadyUnlocked)
        {
            // Here enter the event for the correct combination
            Debug.Log("Password correct");
            _alreadyUnlocked = true;

            // Es. Below the for loop to disable Blinking Material after the correct password
            for (int i = 0; i < _moveRull._rullers.Count; i++)
            {
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>()._isSelect = false;
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();
            }

            StartCoroutine(openLockWaiter());

        }
    }

    IEnumerator openLockWaiter()
    {
            // Play the animation of the lock opening
            _lockerAnimator.SetBool("unlock", true);

            yield return new WaitForSeconds(1.5f);
            
            GameObject.Find("LockerZone").GetComponent<LockerController>().lockOpened = true;

            //Let the lock drop down by the gravity
            GetComponent<Rigidbody>().isKinematic = false;

            //Let the lock disappear in 3 seconds(或许以后可以改成渐变消失)
            //PhotonNetwork.Destroy(gameObject);
            Destroy(gameObject,1f);
            // Play the animation of the door opening
            _doorAnimator.SetBool("Open", true);
            _doorAnimator.SetBool("Close", false);


    }

}
