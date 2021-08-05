using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySteps : MonoBehaviour
{
    public AudioSource grassRun;
    public AudioSource rockRun;
    public AudioSource grassImpact;
    public AudioSource rockImpact;
    private AudioSource step;
    private AudioSource impact;
    public string stepType = "Grassy";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (stepType == "Grassy") {
            step = grassRun;
            impact = grassImpact;
        }
        else {
            step = rockRun;
            impact = rockImpact;
        }
    }
    private void Step()
    {
        step.Play();
    }
    private void Impact() {
        impact.Play();
    }
}
