using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    [SerializeField]
    int hp;
    [SerializeField]
    Slider hpSlider;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (other.gameObject.GetComponent<Bullet>().Owner != this.gameObject)
            {
                Debug.Log("¾Æ¾ß ");
                hp -= 10;
                hpSlider.value = hp;
            }
        }
    }
}
