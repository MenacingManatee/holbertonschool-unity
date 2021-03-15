using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Activate timer on leaving the trigger
    void OnTriggerExit(Collider other) {
        Timer script = other.gameObject.GetComponent<Timer>();
        if (script && script.enabled == false) {
            script.enabled = true;
        }
    }
}
