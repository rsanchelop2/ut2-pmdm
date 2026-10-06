using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosScript : MonoBehaviour
{
    public GameManager gameManager;
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 collisionNormal = collision.contacts[0].normal;
            Vector2 knockbackDirection = -collisionNormal;
            playerRB.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.DesactivarMovimiento(knockbackDuration);
            gameManager.QuitarVidaJugador();
        }
    }

}
