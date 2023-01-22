using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject PlayerPrefab;

    private void Start()
    {
        Vector3 pos = new Vector3(-1,0,1);
        PhotonNetwork.Instantiate(PlayerPrefab.name,pos,Quaternion.identity);
    }
}
