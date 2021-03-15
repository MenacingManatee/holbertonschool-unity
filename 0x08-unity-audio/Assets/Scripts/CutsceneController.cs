using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOn = true;
    public GameObject MainC;
    public GameObject Player;
    private PlayerController PC;
    public Canvas TimerCanvas;
    void Start()
    {
        PC = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == false) {
            MainC.SetActive(true);
            TimerCanvas.gameObject.SetActive(true);
            PC.enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
