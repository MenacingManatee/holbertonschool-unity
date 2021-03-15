using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Player gameobject
    public GameObject player;
    // Camera offset from player
    public Vector3 offset = new Vector3(0, 2.5f, -6.25f);
    // Camera rotation spd
    public float rotationSpd = 5f;
    // Is axis inverted
    public bool isInverted = false;

    private float deltaVertical = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        isInverted = PlayerPrefs.GetInt("isInverted") != 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpd;
        float vertical = Input.GetAxisRaw("Mouse Y") * rotationSpd;
        if (!isInverted)
            deltaVertical = Mathf.Clamp(deltaVertical - vertical, -30f, 20f);
        else
            deltaVertical = Mathf.Clamp(deltaVertical + vertical, -30f, 20f);
        // transform.position = player.transform.position + offset;
        player.transform.Rotate(0, horizontal, 0);

        float newAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(deltaVertical, newAngle, 0);
        transform.position = player.transform.position + (rotation * offset);

        transform.LookAt(player.transform);
    }
}
