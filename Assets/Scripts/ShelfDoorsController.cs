using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfDoorsController : MonoBehaviour
{
    [SerializeField] private float angleX, doorOpenAngle = 0f, doorCloseAngle = 90f, angleZ, openDoorSmoothnes = 5f, closeDoorSmoothnes = 6f;
    [SerializeField] private bool isOpen = false;


    public void MoveDoors()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
        }


        if (!isOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(angleX, doorOpenAngle, angleZ);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, openDoorSmoothnes * Time.deltaTime);


        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(angleX, doorCloseAngle, angleZ);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, closeDoorSmoothnes * Time.deltaTime);
        }

    }


    
}