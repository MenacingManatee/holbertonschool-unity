using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player controller script
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Walk speed of player
    public float walkSpd = 10f;
    // Jump speed of player
    public float jumpSpd = 10f;
    // Player rigidbody
    private Rigidbody rb;
    private Collider coll;
    private bool jumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        coll = GetComponent<Collider>();
    }

    void Update() {
        MovementHandler();

        JumpHandler();
        if (transform.position.y < -30) {
            transform.position = new Vector3(0, 50, 0);
            rb.velocity = new Vector3(0, -15, 0);
        }
    }

    void MovementHandler() {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        float dist = walkSpd * Time.deltaTime;
        Debug.Log("Test");

        // Movement
        Vector3 movement = new Vector3(hAxis * dist, 0f, vAxis * dist);
        movement = Camera.main.transform.TransformDirection(movement);

        // Current position
        Vector3 currPos = transform.position;

        rb.MovePosition(currPos + movement);
    }

    void JumpHandler() {
        float jAxis = Input.GetAxis("Jump");
        bool isGrounded = CheckGrounded();

        if (jAxis > 0f) {
            if (!jumping && isGrounded) {
                Vector3 jumpVect = new Vector3(0f, jumpSpd, 0f);
                jumping = true;
                rb.velocity = rb.velocity + jumpVect;
            }
        }
        else {
            jumping = false;
        }
    }

    bool CheckGrounded() {
        RaycastHit rayHit;
        return (Physics.SphereCast(transform.position, coll.bounds.size.x / 2,
                Vector3.down, out rayHit, coll.bounds.size.y / 2));
    }
}
