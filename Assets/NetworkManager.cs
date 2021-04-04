using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
	
    private GameObject desktop;
    private GameObject screenPositioner;
    private GameObject spawnedPlayerPrefab;
	
    public static string roomID;
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    // Update is called once per frame
    void ConnectToServer()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server...");
    }

    public override void OnConnectedToMaster()
    {
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();

        Debug.Log("Connected to server.");
        base.OnConnectedToMaster();
    }

    public static void JoinARoom() 
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        roomID = DataStore.DS.roomNumber;
        Debug.Log(roomID);
        PhotonNetwork.JoinOrCreateRoom(roomID, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom() 
    {
        Debug.Log("Joined a Room.");
        base.OnJoinedRoom();
		
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Girl4", transform.position, transform.rotation); 
        desktop = PhotonNetwork.Instantiate("VR Desktop Mirror", new Vector3(0, 0, 0), Quaternion.identity, 0);
        screenPositioner = PhotonNetwork.Instantiate("ScreenPositioner (1)", new Vector3(0, 0, 0), Quaternion.identity, 0);
		
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) 
    {
        Debug.Log("A new player has joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
