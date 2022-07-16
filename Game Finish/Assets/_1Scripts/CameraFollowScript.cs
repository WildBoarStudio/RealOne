using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform targetObject;

    public Vector3 cameraOffset;

    [Range(0.01f, 1f)]
    public float smoothFactor = 0.5f;

    public bool rotateAroundPlayer = false;

    public float rotationSpeed = 5.0f;

    public bool lookAtPlayer;
    void Start()
    {
        //cameraOffset = transform.position - targetObject.position;
        //cameraOffset = Vector3.zero;
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
       // transform.position = newPosition;
        Debug.Log("SRSR");
    }


    private void LateUpdate()
    {
        HandleCameraMovement();
    }

    public void HandleCameraMovement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            rotateAroundPlayer = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            rotateAroundPlayer = false;
        }
        if (rotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

            cameraOffset = camTurnAngle * cameraOffset;
        }

        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if (lookAtPlayer || rotateAroundPlayer)
        {
            transform.LookAt(targetObject);
        }
    }
}
