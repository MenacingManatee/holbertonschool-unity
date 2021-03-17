using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySteps : MonoBehaviour
{
    public AudioSource grassRun;
    public AudioSource rockRun;
    private AudioSource step;
    public string stepType = "Grassy";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (stepType == "Grassy")
            step = grassRun;
        else
            step = rockRun;
    }
    private void Step()
    {
        step.Play();
    }
}
