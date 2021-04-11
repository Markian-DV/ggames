using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyManager : MonoBehaviourPunCallbacks
{
    private PhotonView photonView;
    public Text logText;
    public GameObject roomCodeInputField;
    public static string roomCode;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.NickName = DataManager.nickname;

        PhotonNetwork.GameVersion = "1";

        PhotonNetwork.ConnectUsingSettings();

        photonView = GetComponent<PhotonView>();
    }

    public override void OnConnectedToMaster()
    {
        Log("Welcome, " + PhotonNetwork.NickName + "! You are successfully connected to Master.");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
        DataManager.isPlayerWhite = true;
        DataManager.isPlayerBlack = true;
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        DataManager.isPlayerBlack = true;
    }

    public void JoinRoom()
    {
        string roomCode = roomCodeInputField.GetComponent<Text>().text;
        PhotonNetwork.JoinOrCreateRoom(roomCode, new Photon.Realtime.RoomOptions { MaxPlayers = 2 }, null);
        DataManager.isPlayerBlack = true;
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    private void Log(string message)
    {
        Debug.Log(message);
        logText.text += "\n";
        logText.text += message;
    }
}
