using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public PhotonView photonView;
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
        DataManager.isPlayerWhite = false;
        DataManager.isPlayerBlack = false;
    }
    public void Disconnect()
    {
        PhotonNetwork.LeaveRoom();
    }
}
