using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float JumpForce = 2f;
    public float climbSpeed = 4f;

    private float vertical;
    private float horizontal;

    public bool Jumping = false;
    public bool isLadder;
    public bool isClimbing;

    [SerializeField] private GameObject AdultPlayer;
    [SerializeField] private GameObject ChildPlayer;
    [SerializeField] private Rigidbody2D rb;

    void Start() {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontal = Input.GetAxis("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetAxisRaw("Jump") > 0 && Mathf.Abs(rb.velocity.y) < 0.01f) {
            Jumping = true;
        }
        if (isLadder && Mathf.Abs(vertical) > 0f) {
            isClimbing = true;
        }
        if(Input.GetKeyDown("v")) {
            if (ObjectControl.GetPineApple & ObjectControl.GetMotherboard) {
                AdultPlayer.active = !AdultPlayer.active;
                ChildPlayer.active = !ChildPlayer.active;
            }
            else if (ObjectControl.GetPineApple) {
                AdultPlayer.active = false;
                ChildPlayer.active = true;
            }
            else if (ObjectControl.GetMotherboard) {
                AdultPlayer.active = true;
                ChildPlayer.active = false;
            }
            if(AdultPlayer.active) {
                AdultPlayer.transform.position = ChildPlayer.transform.position;
                rb = AdultPlayer.GetComponent<Rigidbody2D>();
            }
            else if (ChildPlayer.active) {
                ChildPlayer.transform.position = AdultPlayer.transform.position;
                rb = ChildPlayer.GetComponent<Rigidbody2D>();
            }
        }
    }

    private void FixedUpdate() {
        if (isClimbing) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbSpeed);
        }
        else {
            rb.gravityScale = 4f;
        }
        if (Jumping == true) {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Jumping = false;
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ladder")) {
            isLadder = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Ladder")) {
            isLadder = false;
            isClimbing = false;
        }
    }

}
