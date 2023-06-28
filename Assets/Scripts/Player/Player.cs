using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//============================================================
// The Player class is the main class for the player.
// The player can jump and move left and right.
// The player can push other players as a special ability.
// The ability has a 2 second cooldown.
// THe player sprite should flip when moving left and right.
//============================================================
public class Player : MonoBehaviour
{
    //============================================================
    // Variables
    //============================================================

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float pushForce = 5f;
    [SerializeField] private float pushCooldown = 2f;
    [SerializeField] private GameObject pushPrefab;

    //============================================================
    // Controls for each player
    //============================================================
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.S;
    [SerializeField] private KeyCode jump = KeyCode.X;
    [SerializeField] private KeyCode push = KeyCode.C;

    //============================================================
    // Private variables
    //============================================================
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isGrounded = false;

    //============================================================
    // Push cooldown variables
    //============================================================
    private bool canPush = true;
    private float pushTimer = 0f;

    //============================================================
    // Unity functions
    //============================================================
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //============================================================
        // Check if the player is grounded
        //============================================================
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        //============================================================
        // Check if the player can push
        //============================================================
        if (!canPush)
        {
            pushTimer += Time.deltaTime;
            if (pushTimer >= pushCooldown)
            {
                canPush = true;
                pushTimer = 0f;
            }
        }

        //============================================================
        // Check if the player is moving left or right
        //============================================================
        if (Input.GetKey(left))
        {
            MoveLeft();
        }
        else if (Input.GetKey(right))
        {
            MoveRight();
        }
        else
        {
            StopMoving();
        }

        //============================================================
        // Check if the player is jumping
        //============================================================
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            Jump();
        }

        //============================================================
        // Check if the player is pushing
        //============================================================
        if (Input.GetKeyDown(push) && canPush)
        {
            Push();
        }
    }

    //============================================================
    // Functions
    //============================================================
    private void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        sr.flipX = true;
        anim.SetBool("isRunning", true);
    }  

    private void MoveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        sr.flipX = false;
        anim.SetBool("isRunning", true);
    }

    private void StopMoving()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        anim.SetBool("isRunning", false);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Push()
    {
        Instantiate(pushPrefab, transform.position, Quaternion.identity);
    }

}
