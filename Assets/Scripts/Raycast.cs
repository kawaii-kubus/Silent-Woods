using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public float Raycastdistance = 5f;

    private Camera _camera;

    private KeyCode interactkey = KeyCode.E;

    private NotesController _notesController;

    [SerializeField] private Image crosshair;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, Raycastdistance))
        {
            var readableItem = hit.collider.GetComponent<NotesController>();
            if (readableItem != null)
            {
                _notesController = readableItem;
                HighlightCrosshair(true);
            }
            else
            {
                ClearNote();
            }
        }      


        if (_notesController != null)
        {
            if (Input.GetKeyDown(interactkey))
            {
                _notesController.ShowNote();
            }
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
