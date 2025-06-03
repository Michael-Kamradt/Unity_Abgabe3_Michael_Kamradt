using System;
using UnityEngine;

/// <summary>
/// Dieses Script steuert den Spieler: Laufen, Springen und Beschleunigen.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 8f; // Maximale Geschwindigkeit, die der Spieler erreichen kann
    [SerializeField] private float acceleration = 10f; // Beschleunigungswert für sanftes Anlaufen
    [SerializeField] private float jumpForce = 12f; // Sprungkraft

    private float input; // Input-Achse horizontal
    private Rigidbody2D playerBody; // Referenz auf das Rigidbody2D des Spielers
    private bool isGrounded; // Flag, ob Spieler auf dem Boden ist

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>(); // Holt das Rigidbody2D-Component
    }

    private void Update()
    {
        input = Input.GetAxisRaw("Horizontal"); // Liest horizontale Eingabe (A/D, Pfeiltasten)

        if (Input.GetButtonDown("Jump") && isGrounded) // Nur springen, wenn grounded
        {
            playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, jumpForce); // Fügt vertikale Geschwindigkeit zum Springen hinzu
        }
    }

    private void FixedUpdate()
    {
        // Zielgeschwindigkeit auf Basis des Inputs berechnen
        float targetSpeed = input * maxMoveSpeed;

        // Momentane Geschwindigkeit sanft an Zielgeschwindigkeit angleichen (Sonic-Feeling)
        float newSpeed = Mathf.Lerp(playerBody.linearVelocity.x, targetSpeed, acceleration * Time.fixedDeltaTime);

        // Setze die neue Geschwindigkeit
        playerBody.linearVelocity = new Vector2(newSpeed, playerBody.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Prüfen, ob Boden berührt wird
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Boden berührt → Grounded true
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Wenn Boden verlassen wird
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Nicht mehr grounded
        }
    }
}
