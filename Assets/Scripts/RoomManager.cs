using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using System;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI statusText;
    //public GameObject placaeholderPlayer;
    public GameObject player;
    [Space]
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ConnectRequest", 10);
        
    }

    private void ConnectRequest()
    {
        PhotonNetwork.AddCallbackTarget(this);
        statusText.text = "RoomManager : Connecting ...." + Time.deltaTime.ToString();
        Debug.Log("RoomManager : Connecting ....");
        try
        {
            //RoomOptions roomOptions = new RoomOptions();
            //roomOptions.MaxPlayers = 10;
            //roomOptions.IsVisible = true;
            //roomOptions.IsOpen = true;
            PhotonNetwork.ConnectUsingSettings();
        }
        catch (Exception e)
        {
            Debug.Log("RoomManager : Connection ERROR : " + e.ToString());
        }
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        statusText.text = "Connected To Server";
        Debug.Log("RoomManager : Connected To Server");
        PhotonNetwork.JoinLobby();
    }

    // Called when connection fails
    public void OnConnectionFail(string errorMessage)
    {
        statusText.text = "Failed to connect to Photon Master server: " + errorMessage;
        Debug.Log("RoomManager : Failed to connect to Photon Master server: " + errorMessage);
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        statusText.text = "We are connected and in a lobby now";
        Debug.Log("RoomManager : We are connected and in a lobby now");

        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        PhotonNetwork.JoinOrCreateRoom("Test", null, null);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        //placaeholderPlayer.SetActive(false);
        statusText.text = "We are connected and in a room now";
        Debug.Log("RoomManager : We are connected and in a room now");
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
//        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }

}
