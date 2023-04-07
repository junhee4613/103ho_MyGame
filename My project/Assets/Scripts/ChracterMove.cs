using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterMove : MonoBehaviour
{
    public float characterSpeed = 0;
    public GameObject characterRender;
    void Start()
    {
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        Color c = characterRender.GetComponent<Renderer>().material.color;

        for (float fadeoffset = 1.0f; fadeoffset >= 0; fadeoffset -= 0.1f)
        {
            c.b = fadeoffset;
            c.g = fadeoffset;
            characterRender.GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(1.0f);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            characterSpeed = 5.0f;
        }
        transform.Translate(0, 0, characterSpeed * Time.deltaTime);

        characterSpeed *= 0.99f;
    }
}
