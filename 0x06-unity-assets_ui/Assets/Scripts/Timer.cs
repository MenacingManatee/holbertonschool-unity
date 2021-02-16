using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Timer gameobject
    public Text Timer_Text;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int m = Mathf.FloorToInt(time / 60f);
        int s = Mathf.FloorToInt(time % 60f);
        int ms = Mathf.FloorToInt((time * 100f) % 100f);
        Timer_Text.text = m.ToString("00") + ":" + s.ToString("00") + "." + ms.ToString("00");
    }
}
