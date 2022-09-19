using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveRotation : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    Vector3 mousePos;

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = cam.farClipPlane;
    }
    private void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(mousePos);
        mousePos.y = this.transform.position.y;
        transform.LookAt(mousePos);
    }


}
