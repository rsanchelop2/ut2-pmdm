using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float hVelocity = 10f;
    public Collider2D feetCollider;
    public LayerMask groundLayer;
    public float jumpforce = 7f;
    private bool isGrounded = false;
    int choques = 0;
    public float velocity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void FixedUpdate() {
        float inputHorizontal = Input.GetAxis("Horizontal");
        //rigidBody2D.velocity = new Vector2(inputHorizontal * hVelocity, rigidBody2D.velocity.y);
        rb.AddForce(Vector2.right * inputHorizontal * hVelocity);
        
        // verifica si el collider de los pies toca el suelo
        isGrounded = feetCollider.IsTouchingLayers(groundLayer);
        if (isGrounded && Input.GetKey(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Colision con: " + other.gameObject.name);
        choques++;
        if (choques == 2){
            Debug.Log("Has ganado");
        }

        
    }
}
