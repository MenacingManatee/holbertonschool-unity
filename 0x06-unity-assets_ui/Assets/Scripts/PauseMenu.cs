using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Canvas
    public GameObject PauseCanvas;
    // Camera
    public GameObject cam;
    // Camera controller script
    private CameraController cc;
    private Component[] optionButtons;
    // Start is called before the first frame update
    void Start()
    {
        cc = cam.gameObject.GetComponent<CameraController>();
        optionButtons = PauseCanvas.GetComponentsInChildren<Button>();
        foreach (Component b in optionButtons) {
            Button bu = b.GetComponent<Button>();
            if (b.name.Substring(0, 6) == "Resume")
                bu.onClick.AddListener(delegate{Resume();});
            if (b.name.Substring(0, 7) == "Restart")
                bu.onClick.AddListener(delegate{Restart();});
            if (b.name.Substring(0, 4) == "Menu")
                bu.onClick.AddListener(delegate{MainMenu();});
            if (b.name.Substring(0, 7) == "Options")
                bu.onClick.AddListener(delegate{Options();});
        }
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
        if (cc && cc.enabled == true) {
            cc.enabled = false;
        }
        Time.timeScale = 0;
        PauseCanvas.SetActive(true);
    }
    public void Resume()
    {
        if (cc && cc.enabled == false) {
            cc.enabled = true;
        }
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }
    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        Resume();
        PlayerPrefs.SetString("sceneHistory", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
}
