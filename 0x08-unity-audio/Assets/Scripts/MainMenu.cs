using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Buttons on canvas
    private Component[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = this.GetComponentsInChildren<Button>();
        foreach (Component b in buttons) {
            Button bu = b.GetComponent<Button>();
            if (b.name.Substring(0, 5) == "Level")
                bu.onClick.AddListener(delegate{LevelSelect(int.Parse(b.name.Substring(b.name.Length - 2)));});
            else if (b.name.Substring(0, 7) == "Options")
                bu.onClick.AddListener(delegate{Options();});
            else if (b.name.Substring(0, 4) == "Exit")
                bu.onClick.AddListener(delegate{ExitGame();});
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene("Level0" + level.ToString());
    }
    public void Options()
    {
        PlayerPrefs.SetString("sceneHistory", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
}
