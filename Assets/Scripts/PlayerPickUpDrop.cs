using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    public Transform cameraLookAt;
    public LayerMask pickUpLayerMask;
    public Transform objectGrabPointTransform;

    public Grabbable grab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grab == null)
            {
                float pickupDistance = 2f;
                if (Physics.Raycast(cameraLookAt.position, cameraLookAt.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out grab))
                    {
                        grab.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                grab.Drop();
                grab = null;
            }

        }
    }
}
