using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    // Timer text
    public Text winText;
    // Win canvas
    public GameObject WinCanvas;
    // BGM
    public AudioSource BGM;

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
        CameraController cam = Camera.main.GetComponent<CameraController>();
        script.Win();
        script.enabled = false;
        cam.enabled = false;
        Time.timeScale = 0;
        BGM.Stop();
        // winText.color = Color.green;
        // winText.fontSize = 70;
        WinCanvas.SetActive(true);
    }
}
