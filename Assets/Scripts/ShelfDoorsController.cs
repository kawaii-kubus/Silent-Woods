using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfDoorsController : MonoBehaviour
{

    [SerializeField] private float angleX, doorOpenAngle = 0f, doorCloseAngle = 90f, angleZ, openDoorSmoothnes = 5f, closeDoorSmoothnes = 6f, raycastDistace = 5f;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject rDoor;




    public void Open()
    {

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hitDoor, raycastDistace))
        {
            if (hitDoor.collider.gameObject.name == rDoor.name)
            {
                Debug.Log("AAAA");
                if (!isOpen)
                {
                    Quaternion targetRotation = Quaternion.Euler(angleX, doorOpenAngle, angleZ);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, openDoorSmoothnes * Time.deltaTime);
                    isOpen = false;

                }
                else
                {
                    Quaternion targetRotation2 = Quaternion.Euler(angleX, doorCloseAngle, angleZ);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, closeDoorSmoothnes * Time.deltaTime);
                    isOpen = true;
                }
            }

        }
    }












}