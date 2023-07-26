using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool alive = true;
    public GameObject punchPrefab;
    public GameObject groundCheck;
    public float speed = 5f;
    public float jumpForce = 5f;
    public float punchCooldown = 2f;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.W;
    public KeyCode punch = KeyCode.Space;
    public KeyCode special = KeyCode.V;
    public SpriteRenderer spriteRenderer;
    public bool facingRight = true;
    public bool isrunning = false;
    public bool isGrounded = false;
    public bool isJumping = false;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Kill()
    {
        alive = false;
        Destroy(gameObject);
    }
}
