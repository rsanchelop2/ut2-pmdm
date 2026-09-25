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

    public float rayLength = 0.5f;

    //private bool isGrounded = false;
    //int choques = 0;
    public float velocity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        if (Input.GetButtonDown("Jump") && hit.collider != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }

        
    }
    void FixedUpdate() {

        //SIN RAYCAST
        // float inputHorizontal = Input.GetAxis("Horizontal");
        // rb.AddForce(Vector2.right * inputHorizontal * hVelocity);
        
        // // verifica si el collider de los pies toca el suelo
        // isGrounded = feetCollider.IsTouchingLayers(groundLayer);
        // if (isGrounded && Input.GetKey(KeyCode.Space)){
        //     rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        // }

        // CON RAYCAST
        float inputHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * inputHorizontal * hVelocity);
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("ultraJump"))
        {
            rb.gravityScale = rb.gravityScale * 2;
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }

}
