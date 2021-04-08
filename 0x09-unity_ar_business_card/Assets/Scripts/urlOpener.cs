using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urlOpener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open() {
        string name = this.name;
        if (string.Compare(name, "Medium") == 0) {
            Application.OpenURL("https://medium.com/@brett.p.davis101");
        }
        else if (string.Compare(name, "LinkedIn") == 0) {
            Application.OpenURL("https://www.linkedin.com/in/brett-davis-132916155/");
        }
        else if (string.Compare(name, "GitHub") == 0) {
            Application.OpenURL("https://www.github.com/MenacingManatee");
        }
        else if (string.Compare(name, "Email") == 0) {
            Application.OpenURL("mailto:brett.p.davis101@gmail.com");
        }
    }
}
