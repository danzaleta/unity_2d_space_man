using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDinoController : MonoBehaviour
{
    // Animator states
    const string STATE_ALIVE = "isAlive";
    const string STATE_GROUNDED = "isGrounded";

    // Paramethers
    [SerializeField] float jumpForce = 2.0f;
    [SerializeField] float runningSpeed = 2.0f;
    [SerializeField] LayerMask groundLayer;

    // Components
    Rigidbody2D rb;
    Animator animator;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }
    //
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_GROUNDED, true);
    }
    
    void Update()
    {
        if (GameManager.gameManagerInstance.currentGameState == GameState.InGame)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                Jump();
            }
            animator.SetBool(STATE_GROUNDED, isGrounded());
        }
        

        Debug.DrawRay(this.transform.position, Vector2.down*0.5f, Color.red);
    }
    //
    void FixedUpdate()
    {
        if (GameManager.gameManagerInstance.currentGameState == GameState.InGame)
        {
            if (rb.velocity.x < runningSpeed)
            {
                rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }


    void Jump()
    {
        if (isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool(STATE_GROUNDED, true);
        }
    }

    bool isGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.5f, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Die()
    {
        this.animator.SetBool(STATE_ALIVE, false);
        rb.AddForce(Vector2.up * 5.5f, ForceMode2D.Impulse);

        GameManager.gameManagerInstance.GameOver();
    }
}
