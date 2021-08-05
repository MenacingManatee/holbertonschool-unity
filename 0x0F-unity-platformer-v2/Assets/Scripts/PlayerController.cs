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
    private Animator animator;
    private bool isGrounded;
    private bool freezeMovement = false;
    private PlaySteps script;
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        coll = GetComponent<Collider>();

        animator = this.transform.GetChild(0).GetComponent<Animator>();

        script = GetComponentInChildren<PlaySteps>();

        keys.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forwards", "W")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Backwards", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backwards", "S")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
    }

    void Update() {
        isGrounded = CheckGrounded();
        freezeMovement = animator.GetBool("IsFalling");
        if (Camera.main != null && !freezeMovement) {
            MovementHandler();

            JumpHandler();
            if (transform.position.y < -30) {
                transform.position = new Vector3(0, 50, 0);
                rb.velocity = new Vector3(0, -15, 0);
                animator.SetBool("IsFalling", true);
            }
        }
        if (animator.GetBool("IsFalling") == true)
            if (isGrounded == true)
                animator.SetBool("IsFalling", false);
    }

    void MovementHandler() {
        float hAxis = (Input.GetKey(keys["Right"]) == true ? 1 : 0) + (Input.GetKey(keys["Left"]) == true ? -1 : 0);
        float vAxis = (Input.GetKey(keys["Forward"]) == true ? 1 : 0) + (Input.GetKey(keys["Backwards"]) == true ? -1 : 0);
        float dist = walkSpd * Time.deltaTime;

        // Movement
        Vector3 movement = new Vector3(hAxis * dist, 0f, vAxis * dist);
        movement = Camera.main.transform.TransformDirection(movement);

        // Current position
        Vector3 currPos = transform.position;

        rb.MovePosition(currPos + movement);
        float temp = (Mathf.Max(movement.x, movement.y, movement.z));
        if (temp != 0) {
            animator.SetBool("IsRunning", true);
        }
        else {
            animator.SetBool("IsRunning", false);
        }
    }

    void JumpHandler() {
        float jAxis = Input.GetKey(keys["Jump"]) == true ? (float)1.0 : (float)0.0;

        if (jAxis > 0f) {
            if (!jumping && isGrounded) {
                Vector3 jumpVect = new Vector3(0f, jumpSpd, 0f);
                jumping = true;
                rb.velocity = rb.velocity + jumpVect;
            }
        }
        else {
            jumping = !isGrounded;
        }
        animator.SetBool("IsJumping", jumping);
    }

    bool CheckGrounded() {
        RaycastHit rayHit;
        return (Physics.SphereCast(transform.position, coll.bounds.size.x / 2,
                Vector3.down, out rayHit, coll.bounds.size.y / 2));
    }
    void OnCollisionEnter(Collision other) {
        string tmp = other.gameObject.tag;

        if (script != null && tmp != null && (tmp == "Rocky" || tmp == "Grassy")) {
            script.stepType = tmp;
        }
    }
}
