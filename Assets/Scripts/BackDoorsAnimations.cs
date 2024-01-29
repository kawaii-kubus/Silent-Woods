using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDoorsAnimations : MonoBehaviour
{
    [Header("Animations")]
    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.E)) 
        {
            //animator.Play();
        }
    }
}
