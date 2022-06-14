using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private float dirX = 0f;    

    public float moveSpeed = 7f;
    public float jumpForce = 14f;
    public LayerMask jumpableGround;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Bewegen
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (dirX > 0f)
        {
            //Charakter schaut nach rechts
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dirX < 0f)
        {
            //Charakter schaut nach links
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private bool IsGrounded()
    {
        //Ground-Check
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
 