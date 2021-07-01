using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    public float moveSpeed = 3f;
    public float jumpForce = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 targetVelocity = Vector2.right * x * moveSpeed;
        targetVelocity.y = rb.velocity.y;

        rb.velocity  = targetVelocity; 
        sprite.flipX = x < 0;
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

    }

    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) > 0f) return;

        rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.CurrentGameState == GameManager.GameState.Gameplay)
        {
            MovePlayer();
        }
    }


    void Update()
    {
        if (GameManager.instance.CurrentGameState == GameManager.GameState.Gameplay)
        {
            MovePlayer();
            if (Input.GetButtonDown("Jump"))
                Jump();
        }
    }

}
