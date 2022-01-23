using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float JumpForce = 100f;
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
    private float clock;
    //private bool age = true;

    void Start() {
        Player = AdultPlayer;
        virtualCam = GetComponentInChildren<CinemachineVirtualCamera>();
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontal = Input.GetAxis("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical");
        if(Mathf.Abs(rb.velocity.y) < 0.01f) {
            myAnimator.SetBool("Jumping", false);
            if (Input.GetAxisRaw("Jump") > 0) {
                Jumping = true;
            }
        }
        
        if (inLadder && Mathf.Abs(vertical) > 0f) {
            onLadder = true;
            myAnimator.SetBool("onLadder", true);
        }
        if (onLadder && Mathf.Abs(rb.velocity.y) < 0.01f) {
            myAnimator.SetBool("isClimbing", false);
        }
        if(horizontal == 0) {
            myAnimator.SetBool("isRunning", false);
        }
        if(Input.GetKeyDown("v")) {

            if(ChildPlayer.active && ObjectControl.GetMotherboard) {
                JumpForce = 100f;
                AdultPlayer.active = true;
                ChildPlayer.active = false;
                Player = AdultPlayer;
                Player.transform.position = ChildPlayer.transform.position;
                rb = Player.GetComponent<Rigidbody2D>();
                virtualCam.Follow = AdultPlayer.transform;
                virtualCam.LookAt = AdultPlayer.transform;
                myAnimator = AdultPlayer.GetComponent<Animator>();
                //age = true;
            }
            else if (AdultPlayer.active && ObjectControl.GetPineApple) {
                JumpForce = 5f;
                AdultPlayer.active = false;
                ChildPlayer.active = true;
                Player = ChildPlayer;
                Player.transform.position = AdultPlayer.transform.position;
                rb = Player.GetComponent<Rigidbody2D>();
                virtualCam.Follow = ChildPlayer.transform;
                virtualCam.LookAt = ChildPlayer.transform;
                myAnimator = ChildPlayer.GetComponent<Animator>();
                //age = false;
            }
        }
        clock -= Time.deltaTime;
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
            myAnimator.SetBool("Jumping", true);
        }
        if(horizontal < 0) {
            if(!onLadder)
                myAnimator.SetBool("isRunning", true);
            Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if(horizontal > 0) {
            if (!onLadder)
                myAnimator.SetBool("isRunning", true);
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
