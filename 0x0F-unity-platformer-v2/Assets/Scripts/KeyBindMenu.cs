using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class KeyBindMenu : MonoBehaviour
{
    // Buttons on canvas
    private Component[] buttons;
    // Background mixer
    public AudioMixer Mixer;
    public AudioSource bgm;
    public Text forwards;
    public Text backwards;
    public Text right;
    public Text left;
    public Text jump;

    // Start is called before the first frame update
    void Start()
    {
        buttons = this.GetComponentsInChildren<Button>();
        foreach (Component b in buttons) {
            Button bu = b.GetComponent<Button>();
            if (b.name.Substring(0, 4) == "Back")
                bu.onClick.AddListener(delegate{Back();});
            if (b.name.Substring(0, 5) == "Reset")
                bu.onClick.AddListener(delegate{SetDefaults();});
            if (b.name.Substring(0, 3) == "Key")
                bu.onClick.AddListener(delegate{BindKey(bu);});
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
        forwards.text = PlayerPrefs.GetString("Forwards", "W");
        left.text = PlayerPrefs.GetString("Left", "A");
        right.text = PlayerPrefs.GetString("Right", "D");
        backwards.text = PlayerPrefs.GetString("Backwards", "S");
        jump.text = PlayerPrefs.GetString("Jump", "Space");
    }
    public void Back()
    {
        string prevScene = PlayerPrefs.GetString("sceneHistory");

        if (string.IsNullOrEmpty(prevScene))
            prevScene = "MainMenu";
        if (prevScene == "MainMenu") {
            if (bgm != null)
                DontDestroyOnLoad(bgm);
        }
        SceneManager.LoadScene(prevScene);
    }
    public void SetDefaults()
    {
        PlayerPrefs.SetString("Forwards", "W");
        PlayerPrefs.SetString("Left", "A");
        PlayerPrefs.SetString("Right", "D");
        PlayerPrefs.SetString("Backwards", "S");
        PlayerPrefs.SetString("Jump", "Space");
    }
    public void BindKey(Button bu)
    {
        Text bText = bu.GetComponentInChildren<Text>();
        foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                bText.text = vKey.ToString();
                PlayerPrefs.SetString(bu.name.Remove(0, 3), vKey.ToString());
            }
        }
    }
}
