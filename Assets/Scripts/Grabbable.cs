using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Rigidbody rb;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        rb.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        rb.useGravity = true;
        
    }

    private void FixedUpdate()
    {
        if(objectGrabPointTransform != null) 
        {
            float lerpSpeed = 10f;
            Vector3 targetPosition = objectGrabPointTransform.position;
            rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed));
            
        }
    }
}
