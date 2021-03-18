using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Buttons on canvas
    private Component[] buttons;
    public AudioSource bgm;

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
        GameObject[] bgms = GameObject.FindGameObjectsWithTag("BGM");
        if (bgms.Length > 1)
        {
            for (var i = 1; i < bgms.Length; i++) {
                Destroy(bgms[i].gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelSelect(int level)
    {
        if (bgm != null)
            bgm.Stop();
        GameObject[] bgms = GameObject.FindGameObjectsWithTag("BGM");
            if (bgms.Length != 0)
                Destroy(bgms[0].gameObject);
        SceneManager.LoadScene("Level0" + level.ToString());
    }
    public void Options()
    {
        if (bgm != null)
            DontDestroyOnLoad(bgm);
        PlayerPrefs.SetString("sceneHistory", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
}
