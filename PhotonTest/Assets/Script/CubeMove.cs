using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left);

        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back);

        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right);

        }
    }
}
