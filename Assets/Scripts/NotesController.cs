using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotesController : MonoBehaviour
{
    [SerializeField]private KeyCode closeKey;
    [SerializeField] TMP_Text noteTextAreaUI;
    [SerializeField] GameObject noteCanvas;
    [SerializeField] private string noteText;
    private bool isOpen = false;

    public void ShowNote()
    {
        noteTextAreaUI.text = noteText;
        noteCanvas.SetActive(true);
        isOpen = true;
    }

    public void DisableNote()
    {
        noteCanvas.SetActive(false);
        isOpen = false;
    }

    private void Update()
    {
        if (isOpen) 
        {
            if(Input.GetKeyDown(closeKey))
            {
                DisableNote();
            }
        }    
    }
}
