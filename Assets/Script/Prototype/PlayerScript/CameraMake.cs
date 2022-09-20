using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMake : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private int Y_correctionValue = 2;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 camTransform = transform.position;
        camTransform.y += Y_correctionValue;
        Instantiate(cam, camTransform, cam.transform.rotation);
    }

}
