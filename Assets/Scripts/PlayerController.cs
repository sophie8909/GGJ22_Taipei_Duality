using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float JumpForce = 10f;
    public float climbSpeed = 4f;

    private float vertical;
    private float horizontal;

    public bool Jumping = false;
    public bool inLadder;
    public bool onLadder;

    [SerializeField] private CinemachineVirtualCamera virtualCam;
    [SerializeField] private Animator myAnimator;
    [SerializeField] private GameObject AdultPlayer;
    [SerializeField] private GameObject ChildPlayer;
    [SerializeField] private Rigidbody2D rb;
    private GameObject Player;

    void Start() {
        Player = ChildPlayer;
        virtualCam = GetComponentInChildren<CinemachineVirtualCamera>();
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontal = Input.GetAxis("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetAxisRaw("Jump") > 0 && Mathf.Abs(rb.velocity.y) < 0.01f) {
            Jumping = true;
        }
        if (inLadder && Mathf.Abs(vertical) > 0f) {
            onLadder = true;
            myAnimator.SetBool("onLadder", true);
        }
        if (onLadder && Mathf.Abs(rb.velocity.y) < 0.01f) {
            myAnimator.SetBool("isClimbing", false);
        }
        if(Input.GetKeyDown("v")) {
            if(ObjectControl.age) {
                JumpForce = 10f;
                AdultPlayer.active = true;
                ChildPlayer.active = false;
                Player = AdultPlayer;
                Player.transform.position = ChildPlayer.transform.position;
                rb = Player.GetComponent<Rigidbody2D>();
                virtualCam.Follow = AdultPlayer.transform;
                virtualCam.LookAt = AdultPlayer.transform;
            }
            else {
                JumpForce = 5f;
                AdultPlayer.active = false;
                ChildPlayer.active = true;
                Player = ChildPlayer;
                Player.transform.position = AdultPlayer.transform.position;
                rb = Player.GetComponent<Rigidbody2D>();
                virtualCam.Follow = ChildPlayer.transform;
                virtualCam.LookAt = ChildPlayer.transform;
            }
        }
    }

    private void FixedUpdate() {
        if (onLadder) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbSpeed);
            myAnimator.SetBool("isClimbing", true);
        }
        else {
            rb.gravityScale = 4f;
        }
        if (Jumping == true) {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Jumping = false;
        }
        if(horizontal < 0) {
            Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if(horizontal > 0) {
            Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ladder")) {
            inLadder = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Ladder")) {
            inLadder = false;
            onLadder = false;
            myAnimator.SetBool("onLadder", false);
            myAnimator.SetBool("isClimbing", false);
        }
    }

}
