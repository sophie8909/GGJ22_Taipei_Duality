using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private bool Jumping = false;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement() {
        if(Input.GetKey("a")) {
            this.gameObject.transform.Translate(new Vector2(-speed, 0) * Time.deltaTime);
        }
        if(Input.GetKey("d")) {
            this.gameObject.transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            Jumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (Jumping == true)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Jumping = false;
        }
    }
}
