using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//============================================================
// The Player class is the main class for the player.
// The player can jump and move left and right.
// The player can push other players as a special ability.
// The ability has a 2 second cooldown.
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

    //============================================================
    // Controls for each player
    //============================================================
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.S;
    [SerializeField] private KeyCode jump = KeyCode.X;
    [SerializeField] private KeyCode push = KeyCode.C;

    private void Start() {
        
    }

}
