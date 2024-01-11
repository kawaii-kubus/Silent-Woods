using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    [SerializeField] private GameObject text;
    void Start()
    {
        text.SetActive(true);
        StartCoroutine(TextDisableAfterSeconds());
    }

    private IEnumerator TextDisableAfterSeconds()
    {
        yield return new WaitForSeconds(5f);
        text.SetActive(false);
    }
}
