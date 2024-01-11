using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorsOpen : MonoBehaviour
{

    [SerializeField] private float angleX, doorOpenAngle = 0f, doorCloseAngle = 90f, angleZ, openDoorSmoothnes = 5f, closeDoorSmoothnes = 6f, raycastDistace = 5f;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject door;
    private RaycastHit hitD;


    void Update()
    {


        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hitD, raycastDistace))
        {
            if (hitD.collider.gameObject.name == door.name)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    bool isOpen = false;
                   
                    if (isOpen)
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
        }

       


    }


}