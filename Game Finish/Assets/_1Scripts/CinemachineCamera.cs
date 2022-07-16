using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCamera : MonoBehaviour
{
   [SerializeField] private CinemachineFreeLook cineCamera;
   [SerializeField] private bool shouldRotate;
   [SerializeField] private float rotSpeedX;
   [SerializeField] private float rotSpeedY;

    private float currentMouseX;
    private float currentMouseY;
    

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {// if player right clicks we grab x,y coordinates and change camera accordingly , reset them when he lets go

        if (Input.GetMouseButtonDown(1))
        {
            //on right click we set the rotation to true and grab the current x,y values
            shouldRotate = true;
            currentMouseX = Input.mousePosition.x;
            currentMouseY = Input.mousePosition.y;
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            //once let goes of mouse we stop the rotation
            shouldRotate = false;
            
        }

        if(shouldRotate)
        {
            //get the differences between mouse x , y between when we clicked and now
            float diffX = currentMouseX - Input.mousePosition.x;
            diffX = diffX * rotSpeedX;

            float diffY = currentMouseY - Input.mousePosition.y;
            diffY = diffY * rotSpeedY;

            //apply the differences
            cineCamera.m_XAxis.Value -= diffX;
            cineCamera.m_YAxis.Value += diffY;

            //last bit of code will be resetting the differences so we can recalculate them
            diffX = 0;
            diffY = 0;
        }
    }

}
