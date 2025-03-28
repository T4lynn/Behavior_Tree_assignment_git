using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotted : MonoBehaviour
{
    public GameObject exclamationMark;
    Color exColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ExclamationPoint());
    }
    
    IEnumerator ExclamationPoint()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            exColor = exclamationMark.GetComponent<SpriteRenderer>().color;
            exColor.a = 0f;
            exColor = exclamationMark.GetComponent<SpriteRenderer>().color;
            exclamationMark.SetActive(true);
            new WaitForSeconds(0.2f);
            exColor.a = 0.2f;
            exColor = exclamationMark.GetComponent<SpriteRenderer>().color;
            new WaitForSeconds(0.2f);
            exColor.a = 0.4f;
            exColor = exclamationMark.GetComponent<SpriteRenderer>().color;
            new WaitForSeconds(0.2f);
            exColor.a = 0.6f;
            exColor = exclamationMark.GetComponent<SpriteRenderer>().color;
            new WaitForSeconds(0.2f);
            exColor.a = 0.8f;
            exColor = exclamationMark.GetComponent<SpriteRenderer>().color;
            new WaitForSeconds(0.2f);
            exColor.a = 1f;
            exColor = exclamationMark.GetComponent<SpriteRenderer>().color;
           yield return null;
        }
    }
}
