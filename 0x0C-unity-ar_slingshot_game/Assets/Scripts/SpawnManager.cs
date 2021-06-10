using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public InputManager inputManager;
    public List<GameObject> targetArray;
    public float maxTargets = 5;
    public float spawnDelay = 3;
    private float Timer;
    private float x_dim;
    private float y_dim;

    // Start is called before the first frame update
    void Start()
    {
        targetArray = new List<GameObject>();
        Timer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        var plane = inputManager.plane;
        x_dim = plane.size.x;
        y_dim = plane.size.y;
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0 && targetArray.Count < maxTargets) {
            spawnNewTarget();
            spawnDelay = Timer;
        }
    }
    void spawnNewTarget() {
        var newTarget = GameObject.Instantiate(targetPrefab, Vector3.zero, Quaternion.identity, inputManager.plane.gameObject.transform) as GameObject;
        var x_rand = Random.Range(-x_dim, x_dim);
        var z_rand = Random.Range(-y_dim, y_dim);
        newTarget.transform.position = new Vector3(x_rand, 0, z_rand);
        targetArray.Add(newTarget);
    }
}
