using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]private GameObject flashlightPrefab;
    private bool flashlightLoaded;

    private void Start()
    {
        flashlightPrefab.SetActive(false);
        bool flashlightLoaded = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(flashlightLoaded == false)
            {
                flashlightPrefab.SetActive(true);
                flashlightLoaded = true;
            }          
            else
            {
                flashlightPrefab.SetActive(false);
                flashlightLoaded = false;
            }
        }

    }
}
