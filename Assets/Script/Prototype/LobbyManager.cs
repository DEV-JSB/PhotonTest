using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    int startPlayerCount = 8;
    public int connectCount = 0;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI connectText;

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
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 20 },null);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("���� ����");
    }
    // �������� ������ ���̸� ������ �ȴ� ��� �ϸ� ������
    // ������ ���� ������ �������̶�� ����ؼ� Ǯ�� á���� �˻縦 �ϰ� �ʹ�.
    // ��� �ϸ� ������
    // ������Ʈ���� �������ұ�
    // ���� �׷� �ʿ䰡 ����
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
