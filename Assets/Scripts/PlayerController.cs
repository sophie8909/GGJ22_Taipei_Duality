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
            AdultPlayer.active = !AdultPlayer.active;
            ChildPlayer.active = !ChildPlayer.active;
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
    //public float moveSpeed;
    //public float JumpForce;
    //public float climbSpeed;
    
    //public bool Jumping = false;
    //public bool EnterLadder = false;
    //public bool OnLadder = false;


    

    //private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    //void Start()
    //{
    //    _rigidbody = GetComponent<Rigidbody2D>();
    //    gravityStore = _rigidbody.gravityScale;
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    Movement();
    //}

    //private void Movement() {
    //    if (Input.GetKey("a")) {
    //        //_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -moveSpeed);
    //        this.gameObject.transform.Translate(new Vector2(-moveSpeed, 0) * Time.deltaTime);
    //    }
    //    if (Input.GetKey("d")) {
    //        //_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, moveSpeed);
    //        this.gameObject.transform.Translate(new Vector2(moveSpeed, 0) * Time.deltaTime);
    //    }
    //    if (EnterLadder && Input.GetKey("w")) {
    //        OnLadder = true;
    //        this.gameObject.transform.Translate(new Vector2(0, climbSpeed) * Time.deltaTime);
    //    }
    //    if (EnterLadder && Input.GetKey("s")) {
    //        OnLadder = true;
    //        this.gameObject.transform.Translate(new Vector2(0, -climbSpeed) * Time.deltaTime);
    //    }
    //    if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.01f)
    //    {
    //        Jumping = true;
    //        OnLadder = false;
    //    }
    //    if(Input.GetButtonDown("Jump")) {
    //        Debug.Log("Jump");
    //        Debug.Log(Mathf.Abs(_rigidbody.velocity.y));
    //    }
    //    if (OnLadder) {
    //        _rigidbody.gravityScale = 0f;
    //        _rigidbody.velocity = new Vector2(0f, 0f);
    //        Jumping = false;
    //    }
    //    if (!OnLadder) {
    //        _rigidbody.gravityScale = gravityStore;
    //    }
    //    if (!EnterLadder) {
    //        OnLadder = false;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (Jumping == true)
    //    {
    //        _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    //        Jumping = false;
    //    }
    //}


}
