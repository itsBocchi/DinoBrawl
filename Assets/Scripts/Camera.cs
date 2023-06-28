using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // The camera should scroll up and accelerate as the game progresses
    // The camera should STOP scrolling when the player dies
    // The camera will be fixed on the x-axis

    public float speed = 0.1f;
    public float acceleration = 0.1f;
    public float maxSpeed = 3.2f;

    [HideInInspector]
    public bool moveCamera;

    private float speedTimeOrigin;
    private float accelerationTimeOrigin;
    private float maxSpeedTimeOrigin;

    private void Start()
    {
        speedTimeOrigin = speed;
        accelerationTimeOrigin = acceleration;
        maxSpeedTimeOrigin = maxSpeed;
        moveCamera = true;
    }

    private void Update()
    {
        if (moveCamera)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y + (speed * Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y, newY, oldY);
        transform.position = temp;

        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void ResetCameraSpeed()
    {
        speed = speedTimeOrigin;
        acceleration = accelerationTimeOrigin;
        maxSpeed = maxSpeedTimeOrigin;
    }

    public void StopCamera()
    {
        moveCamera = false;
    }

    public void StartCamera()
    {
        moveCamera = true;
    }

}
