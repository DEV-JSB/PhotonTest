using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    int startPlayerCount = 4;
    public int connectCount = 0;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI connectText;


    int roomCount = 0;
    string defaultRoomName = "Room";


    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
    }
    public void Connect()
    {
        Debug.Log("Connect");
        PhotonNetwork.LocalPlayer.NickName = nameText.text;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        
        PhotonNetwork.JoinOrCreateRoom("Room"+ roomCount.ToString(), new RoomOptions { MaxPlayers = 2 },null);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("접속 실패");
        ++roomCount;
        PhotonNetwork.JoinOrCreateRoom("Room" + roomCount.ToString(), new RoomOptions { MaxPlayers = 2 }, null);
      
    }
    // 마지막에 접속한 아이만 접속이 된다 어떻게 하면 좋을까
    // 마지막 말고 서버가 접속중이라면 계속해서 풀로 찼는지 검사를 하고 싶다.
    // 어떻게 하면 좋을까
    // 업데이트문을 돌려야할까
    // 굳이 그럴 필요가 있을
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        
        if (startPlayerCount == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            GetComponent<PhotonView>().RPC("LoadingInGame", RpcTarget.All);
        }
        else if (PhotonNetwork.IsConnected)
        {
            connectCount = PhotonNetwork.CurrentRoom.PlayerCount;
            connectText.GetComponent<ConnectCountText>().RefreshServerText(connectCount);
        }
    }

    [PunRPC]
    private void LoadingInGame()
    {
        PhotonNetwork.LoadLevel("Map");

    }
}
