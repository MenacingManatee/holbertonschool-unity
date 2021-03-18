using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    // Toggle
    public Toggle yToggle;
    // Buttons on canvas
    private Component[] buttons;
    // Background mixer
    public AudioMixer Mixer;
    // BGM slider
    public Slider bgmSlider;
    public Slider sfxSlider;
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("isInverted"))
        {
            yToggle.isOn = PlayerPrefs.GetInt("isInverted") != 0;
        }
        if (PlayerPrefs.HasKey("BGMVolume")) {
            bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        }
        if (PlayerPrefs.HasKey("SFXVolume")) {
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
        buttons = this.GetComponentsInChildren<Button>();
        foreach (Component b in buttons) {
            Button bu = b.GetComponent<Button>();
            if (b.name.Substring(0, 4) == "Back")
                bu.onClick.AddListener(delegate{Back();});
            if (b.name.Substring(0, 5) == "Apply")
                bu.onClick.AddListener(delegate{Apply();});
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
        Mixer.SetFloat("BGM", SetVolume(bgmSlider.value));
        PlayerPrefs.SetFloat("BGMVolume", bgmSlider.value);
        Mixer.SetFloat("SFX", SetVolume(sfxSlider.value));
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
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
    public void Apply()
    {
        PlayerPrefs.SetInt("isInverted", yToggle.isOn ? 1 : 0);
    }
    public float SetVolume (float sliderValue) {
        float db;
        if (sliderValue != 0)
            db = 20.0f * Mathf.Log10(sliderValue);
        else
            db = -144.0f;
        return (db);
    }
}
