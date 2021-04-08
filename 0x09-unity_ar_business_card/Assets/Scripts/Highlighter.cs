using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public GameObject toHighlight;
    private Color baseColor;
    private Color newColor = new Color(0.8f, 0.4f, 0.3f);
    // Start is called before the first frame update
    void Start()
    {
        baseColor = toHighlight.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highlight() {
        gameObject.GetComponent<Renderer>().material.color = newColor;
        toHighlight.GetComponent<Renderer>().material.color = newColor;
    }
    public void unHighlight() {
        toHighlight.GetComponent<Renderer>().material.color = baseColor;
        gameObject.GetComponent<Renderer>().material.color = baseColor;
    }
}
