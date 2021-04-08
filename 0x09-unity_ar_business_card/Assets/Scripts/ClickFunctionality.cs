using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunctionality : MonoBehaviour
{
    private GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("clickable");
    }

    void Update () {
        foreach (var b in buttons) {
            b.GetComponent<Highlighter>().unHighlight();
        }
    }

    // Update is called once per frame
    void LateUpdate () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
				if(hit.collider.tag == "clickable")
				{
                    GameObject obj = hit.collider.gameObject;
                    obj.GetComponent<Highlighter>().Highlight();
                    if (Input.GetMouseButtonDown(0)){ // if left button pressed...
	    				obj.GetComponent<urlOpener>().Open();
                    }
				}
			}
	}
}
