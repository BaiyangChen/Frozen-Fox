using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = new Vector3(3f, 3f, -10f);
    private Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.position.x + offset.x, transform.position.y, target.position.z + offset.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.25f);
    }
}
