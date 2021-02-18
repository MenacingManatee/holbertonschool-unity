using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Canvas
    public GameObject PauseCanvas;
    // Camera
    public GameObject cam;
    // Timer script
    private Timer script;
    // Player controller script
    private PlayerController controller;
    // Camera controller script
    private CameraController cc;
    // Start is called before the first frame update
    void Start()
    {
        script = this.gameObject.GetComponent<Timer>();
        controller = this.gameObject.GetComponent<PlayerController>();
        cc = cam.gameObject.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (PauseCanvas.activeSelf)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        if (script && script.enabled == true) {
            script.enabled = false;
        }
        if (controller && controller.enabled == true) {
            controller.enabled = false;
        }
        if (cc && cc.enabled == true) {
            cc.enabled = false;
        }
        PauseCanvas.SetActive(true);
    }
    public void Resume()
    {
        if (script && script.enabled == false) {
            script.enabled = true;
        }
        if (controller && controller.enabled == false) {
            controller.enabled = true;
        }
        if (cc && cc.enabled == false) {
            cc.enabled = true;
        }
        PauseCanvas.SetActive(false);
    }
}
