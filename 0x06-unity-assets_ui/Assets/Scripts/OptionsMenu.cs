using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    // Buttons on canvas
    private Component[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = this.GetComponentsInChildren<Button>();
        foreach (Component b in buttons) {
            Button bu = b.GetComponent<Button>();
            if (b.name.Substring(0, 4) == "Back")
                bu.onClick.AddListener(delegate{Back();});
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
}
