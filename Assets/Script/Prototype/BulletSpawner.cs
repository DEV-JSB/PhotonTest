using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos;
        //mousePos = Input.mousePosition;
        //mousePos = cam.ScreenToWorldPoint(mousePos);

        //mousePos = new Vector3( mousePos.x - this.transform.position.x
        //                        , mousePos.y - this.transform.position.y
        //                        , mousePos.z - this.transform.position.z );
        //bulletDirection = mousePos.normalized;

        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 bulletDirection = Input.mousePosition;
            bulletDirection = cam.ScreenToWorldPoint(bulletDirection);
            bulletDirection.y = this.transform.position.y;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(bulletDirection);
        }

    }
}
