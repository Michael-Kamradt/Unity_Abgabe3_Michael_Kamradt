using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    
    private float input;
    private Rigidbody2D playerBody;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        playerBody.linearVelocity = new Vector2(input * moveSpeed, playerBody.linearVelocity.y);
        
        if (Input.GetButtonDown("Jump"))
        {
                playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, jumpForce);
        } 
    }
}
