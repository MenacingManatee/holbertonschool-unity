using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    // Toggle
    public Toggle yToggle;
    // Buttons on canvas
    private Component[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("isInverted"))
        {
            yToggle.isOn = PlayerPrefs.GetInt("isInverted") != 0;
        }
        buttons = this.GetComponentsInChildren<Button>();
        foreach (Component b in buttons) {
            Button bu = b.GetComponent<Button>();
            if (b.name.Substring(0, 4) == "Back")
                bu.onClick.AddListener(delegate{Back();});
            if (b.name.Substring(0, 5) == "Apply")
                bu.onClick.AddListener(delegate{Apply();});
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        string prevScene = PlayerPrefs.GetString("sceneHistory");

        if (string.IsNullOrEmpty(prevScene))
            prevScene = "MainMenu";
        SceneManager.LoadScene(prevScene);
    }
    public void Apply()
    {
        PlayerPrefs.SetInt("isInverted", yToggle.isOn ? 1 : 0);
    }
}
