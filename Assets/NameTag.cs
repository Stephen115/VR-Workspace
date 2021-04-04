using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameTag : MonoBehaviour
{
    public string username;
    public PhotonView photonView;
    public TextMeshPro name;
    // Start is called before the first frame update
    void Start()
    {
        //name = GetComponent<TextMeshProUGUI>();
        //username = PhotonNetwork.NickName;
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA " + PhotonNetwork.NickName);
        Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB " + name.text);
        if (photonView.IsMine)
        {
            name.text = PhotonNetwork.NickName;
        }
        else 
        {
            name.text = photonView.Owner.NickName;
        }

    }
}
