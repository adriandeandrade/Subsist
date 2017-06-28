using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;
    public Camera cam;

    public Vector3 offset;

    private void LateUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector3 direction = (target.position - cam.transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = transform.rotation.x;
        lookRotation.y = transform.rotation.y;
        lookRotation.z = transform.rotation.z;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 100);

        transform.position = Vector3.Slerp(transform.position, target.position + offset, Time.deltaTime * speed);
    }
}
