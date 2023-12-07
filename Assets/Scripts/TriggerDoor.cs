using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private Animator door;
    [SerializeField] private bool openDoor;
    [SerializeField] private bool closeDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) 
        { 
            if(openDoor) 
            {
                door.Play("DoorOpen");
                gameObject.SetActive(false);
            }
            else if(closeDoor)
            {
                door.Play("DoorClose");
                gameObject.SetActive(false);
            }
        }
    }
}
