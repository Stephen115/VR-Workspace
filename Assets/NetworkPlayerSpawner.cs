using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    public int characterModelID;
    public string characterModelName;

    public override void OnJoinedRoom() 
    {
        base.OnJoinedRoom();
        characterModelID = DataStore.DS.characterID;

        if (characterModelID == 1)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Guy1", transform.position, transform.rotation);
        } else if (characterModelID == 2)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Guy2", transform.position, transform.rotation);
        }
        else if (characterModelID == 3)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Guy3", transform.position, transform.rotation);
        }
        else if (characterModelID == 4)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Girl5", transform.position, transform.rotation);
        }
        else if (characterModelID == 5)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Girl2", transform.position, transform.rotation);
        }
        else if (characterModelID == 6)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Girl4", transform.position, transform.rotation);
        }
        //spawnedPlayerPrefab = PhotonNetwork.Instantiate("Girl4", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
