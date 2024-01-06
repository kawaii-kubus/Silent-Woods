using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    private ShelfDoorsController _shelfDoorsController;
    private Camera _camera;
    private float raycastDistance = 5f;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        //Raycasting to RDoorScript
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hitRDoor, raycastDistance))
        {
            var RDoorScript = hitRDoor.collider.GetComponent<ShelfDoorsController>();
            if (RDoorScript != null)
            {
                _shelfDoorsController = RDoorScript;
                RDoorScript.MoveDoors();
            }

        }



    }
}
