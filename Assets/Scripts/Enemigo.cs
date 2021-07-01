using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    bool tocando;
    public float walkSpeed;
    public static bool mustPatrol;
    public Rigidbody2D rb;
    private bool mustTurn;
    public Transform groundCheckpos;
    public LayerMask groundLayer;
    void Start()
    {


    }

    void Update()
    {
        if (GameManager.instance.CurrentGameState == GameManager.GameState.Gameplay)
        {
            if (mustPatrol)
            {
                Patrol();
            }
        }

    }
    void FixedUpdate()
    {
        if (GameManager.instance.CurrentGameState == GameManager.GameState.Gameplay)
        {
            if (mustPatrol)
            {
                mustTurn = !Physics2D.OverlapCircle(groundCheckpos.position, 0.1f, groundLayer);
            }
        }
    }
    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player") && !tocando)
        {
            Debug.Log("Te moriste");
            GameManager.instance.SetGameState(GameManager.GameState.GameOver);
        }

    }
}
