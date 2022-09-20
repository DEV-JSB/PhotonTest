using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TextMeshProUGUI nameText;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
    }
    public void Connect()
    {
        PhotonNetwork.LocalPlayer.NickName = nameText.text;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 20 },null);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("접속 실패");
    }
    public override void OnJoinedRoom()
    {
            Debug.Log("레벨 로딩");
            PhotonNetwork.LoadLevel("Map");
    }
}
