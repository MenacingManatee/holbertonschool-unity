using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InputManager : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public ARRaycastManager raycastManager;
    private ARPlane plane;
    public Camera AR_Camera;
    public GameObject searchPanel;
    public GameObject selectPanel;
    public GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        searchPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (plane == null && planeManager.trackables.count >= 1)
        {
            searchPanel.SetActive(false);
            selectPanel.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = AR_Camera.ScreenPointToRay(Input.mousePosition);
            if (plane == null)
            {
                var planes = planeManager.trackables;
                var hits = new List<ARRaycastHit>();
                raycastManager.Raycast(ray, hits, TrackableType.PlaneWithinBounds);
                if (hits.Count > 0)
                {
                    plane = planeManager.GetPlane(hits[0].trackableId);
                    selectPanel.SetActive(false);
                    startButton.SetActive(true);
                    planeManager.enabled = false;
                }
            }
        }
        foreach (var Plane in planeManager.trackables)
        {
            if (Plane != plane)
                Plane.enabled = false;
        }
    }
}
