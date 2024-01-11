using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LockedDoors : MonoBehaviour
{
    [SerializeField] private GameObject _rDoors, _lDoors;
    [SerializeField] private float raycastDistance = 5f;
    [SerializeField] private GameObject _textPanel;
    [SerializeField] private Camera _camera;
    private RaycastHit playerHit;


    void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out playerHit, raycastDistance))
        {
            if (playerHit.collider.gameObject.name == _rDoors.name || playerHit.collider.gameObject.name == _lDoors.name)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _textPanel.SetActive(true);
                    StartCoroutine(DisableTextAfterSeconds());

                    
                }
            }
        }
    }

    private IEnumerator DisableTextAfterSeconds()
    {
        yield return new WaitForSeconds(5f);
        _textPanel.SetActive(false);

    }
}

