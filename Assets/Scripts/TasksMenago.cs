using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TasksMenago : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textMeshPro;
    [SerializeField] public string text;
    [SerializeField] public GameObject TextM;
    void Start()
    {
        TextM.SetActive(true);
        textMeshPro.text = text;
        StartCoroutine(DisableTextAfterSeconds());

    }

    private IEnumerator DisableTextAfterSeconds()
    {
        yield return new WaitForSeconds(5f);
        TextM.SetActive(false);



    }



}
