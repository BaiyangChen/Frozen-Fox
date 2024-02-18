using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(3f, 3f, -10f);
    private Vector3 speed = Vector3.zero;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref speed, 0.25f);
    }
}
