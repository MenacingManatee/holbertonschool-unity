using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    // Timer text
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Timer script = other.gameObject.GetComponent<Timer>();
        script.enabled = false;
        winText.color = Color.green;
        winText.fontSize = 70;
    }
}
