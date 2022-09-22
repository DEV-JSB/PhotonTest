using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthScript : MonoBehaviourPun
{
    [SerializeField]
    int hp;
    [SerializeField]
    Slider hpSlider;
    [SerializeField]
    GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        // �浹 ������ ������ ���п� �ſ� �߿��� ���� ������ ���� MasterClient ������ �Ѵ�.
        if(PhotonNetwork.IsMasterClient && other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (other.gameObject.GetComponent<Bullet>().owner != player)
            {
                photonView.RPC("RefreshHealthUI", RpcTarget.All);
            }
        }
    }
    [PunRPC]
    private void RefreshHealthUI()
    {
        hp -= 10;
        hpSlider.value = hp;
    }
}
