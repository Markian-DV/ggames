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
    public Text Score;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.NickName = DataManager.nickname;

        PhotonNetwork.GameVersion = "1";

        PhotonNetwork.ConnectUsingSettings();

        photonView = GetComponent<PhotonView>();

        Score.text = "Your score: " + DataManager.Score;
    }

    public override void OnConnectedToMaster()
    {
        Log("Welcome, " + PhotonNetwork.NickName + "!");
    }

    public void CreateRoom()
    {
        DataManager.isPlayerBlack = true;
        DataManager.isPlayerWhite = true;
        string roomCode = roomCodeInputField.GetComponent<Text>().text;
        PhotonNetwork.CreateRoom(roomCode, new Photon.Realtime.RoomOptions { MaxPlayers = 2, IsVisible = false });
        
    }

    public void QuickGame()
    {

        DataManager.isPlayerBlack = true;
        PhotonNetwork.JoinRandomRoom();
    }
    public void EnterRoom()
    {
        DataManager.isPlayerBlack = true;
        string roomCode = roomCodeInputField.GetComponent<Text>().text;
        PhotonNetwork.JoinRoom(roomCode);
    }   
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        DataManager.isPlayerBlack = true;
        DataManager.isPlayerWhite = true;
        Debug.Log("123");
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
        
        
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
