using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] private float smooth;
    [SerializeField] private float timeCount = 0.0f;

    public Transform cameraLookAt;
    public LayerMask unlockLayerMask;
    public Transform objectGrabPointTransform;

    public Opening door;

    private Quaternion target;
    //[SerializeField] private bool closedDoor = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            float unlockDistance = 5f;
            if (Physics.Raycast(cameraLookAt.position, cameraLookAt.forward, out RaycastHit raycastHit, unlockDistance, unlockLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out door))
                {
                    target = Quaternion.Euler(0f, 90f, 0f);
                    door.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * timeCount);

                }
            }



        }
    }
}
