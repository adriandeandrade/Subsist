using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Other Camera Settings")]
    public GameObject target;
    public Vector3 offset;

    [Space]

    [Header("Speed Settings")]
    public float speed;
    public float horizontalRotationSpeed = 2f;
    public float verticalRotationSpeed = 2f;

    private float cameraYaw = 0.0f;
    private float cameraPitch = 0.0f;

    private void Start()
    {
        if (FindObjectOfType<PlayerController>() != null)
        {
            target = FindObjectOfType<PlayerController>().gameObject;
        }
    }

    private void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, speed * Time.deltaTime);
        //RotateCamera();
    }

    void RotateCamera()
    {
        cameraYaw += horizontalRotationSpeed * Input.GetAxis("Mouse X");
        cameraPitch -= verticalRotationSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(cameraPitch, cameraYaw, 0.0f);
    }
}
