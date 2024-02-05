using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private KeyCode interactkey = KeyCode.E;
    private NotesController _notesController;
    [SerializeField] private LayerMask layerMasInteract;
    [SerializeField] private string excluseLayerName = null;
    [SerializeField] private Camera _camera;
    [SerializeField] private float Raycastdistance = 5f;
    [SerializeField] private Image crosshair;

    private KeyItemController raycastedObject;
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;
    private bool doOnce;

    private string interactableTag = "InteractiveObject";


    void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, Raycastdistance))
        {
            var readableItem = hit.collider.GetComponent<NotesController>();
            var AnimationController = hit.collider.GetComponent<AnimationController>();
            if (AnimationController)
            {
                AnimationController.Open();
                
            }

            if (readableItem != null)
            {
                _notesController = readableItem;
                HighlightCrosshair(true);
            }

            if (readableItem != null)
            {
                if (Input.GetKeyDown(interactkey))
                {
                    _notesController.ShowNote();
                    ClearNote();
                }

            }

        }
        else
        {
            ClearNote();
        }
    }

    void ClearNote()
    {
        if (_notesController != null)
        {
            HighlightCrosshair(false);
            _notesController = null;
        }
    }

    void HighlightCrosshair(bool on)
    {

        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }
}
