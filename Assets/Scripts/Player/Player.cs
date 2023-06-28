using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//============================================================
// The Player class is the main class for the player.
// The player can jump and move left and right.
// The player can punch other players as a special ability.
// The ability has a 2 second cooldown.
//============================================================
public class Player : MonoBehaviour
{
    //============================================================
    // Variables
    //============================================================

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float punchCooldown = 2f;
    public GameObject punchPrefab;
    private bool facingRight = true;
    SpriteRenderer spriteRenderer;
    public GameObject groundCheck;
    bool isrunning = false;


    //============================================================
    // Controls for each player
    //============================================================
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.S;
    [SerializeField] private KeyCode jump = KeyCode.X;
    [SerializeField] private KeyCode punch = KeyCode.C;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {        
        if (Input.GetKeyDown(jump)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
  
        }
        if (Input.GetKeyDown(punch) && punchCooldown <= 0) {
            Punch();
            punchCooldown = 2f;
        }
        punchCooldown -= Time.deltaTime;
    }
    private void FixedUpdate() {
        if (Input.GetKey(left)) {
            transform.position += Vector3.left * speed * Time.fixedDeltaTime;
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(right)) {
            transform.position += Vector3.right * speed * Time.fixedDeltaTime;
            spriteRenderer.flipX = false;
        }
    }

    void Punch() {
        if (facingRight){
            GameObject punch = Instantiate(punchPrefab, transform.position + Vector3.right, Quaternion.identity);
        } else {
            GameObject punch = Instantiate(punchPrefab, transform.position + Vector3.left, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Killzone")) {
            GameOver();
            Destroy(gameObject);
        }
    }

    void GameOver() {
        Debug.Log("Game Over!");
    }
}
