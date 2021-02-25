using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private Component[] optionButtons;
    // Start is called before the first frame update
    void Start()
    {
        optionButtons = this.GetComponentsInChildren<Button>();
        foreach (Component b in optionButtons) {
            Button bu = b.GetComponent<Button>();
            if (b.name.Substring(0, 4) == "Menu")
                bu.onClick.AddListener(delegate{MainMenu();});
            else if (b.name.Substring(0, 4) == "Next")
                bu.onClick.AddListener(delegate{Next();});
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Next()
    {
        string NextScene = SceneManager.GetActiveScene().name;
        NextScene = NextScene.Substring(0, 6) + (int.Parse(NextScene.Substring(6)) + 1).ToString();
        if (Application.CanStreamedLevelBeLoaded(NextScene))
        {
            SceneManager.LoadScene(NextScene);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
