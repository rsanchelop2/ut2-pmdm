using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Collider2D feetCollider;
    public LayerMask groundLayer;
    public float jumpforce = 7f;

    [Header("Configuración de Raycasts")]
    public float rayLength = 0.5f;
    public float sideOffset = 0.4f; 

    [Header("Movimiento")]
    // Hemos eliminado hVelocity y dejado solo esta variable para la velocidad
    public float velocity = 18f; 

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");

        GestionarGiro(inputMovimiento);
        GestionarSalto();

    }

    public void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        GestionarMovimiento(inputHorizontal);
        GestionarSalto();
    }

    void GestionarSalto()
    {
        Vector2 originCenter = transform.position;
        Vector2 originLeft = new Vector2(transform.position.x - sideOffset, transform.position.y);
        Vector2 originRight = new Vector2(transform.position.x + sideOffset, transform.position.y);

        RaycastHit2D hitCenter = Physics2D.Raycast(originCenter, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(originLeft, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(originRight, Vector2.down, rayLength, groundLayer);

        bool isGrounded = (hitCenter.collider != null || hitLeft.collider != null || hitRight.collider != null);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ultraJump"))
        {
            rb.gravityScale = rb.gravityScale * 2;
        }
    }

    void GestionarGiro(float input)
    {
        Vector2 originCenter = transform.position;
        Vector2 originLeft = new Vector2(transform.position.x - sideOffset, transform.position.y);
        Vector2 originRight = new Vector2(transform.position.x + sideOffset, transform.position.y);

        RaycastHit2D hitCenter = Physics2D.Raycast(originCenter, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(originLeft, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(originRight, Vector2.down, rayLength, groundLayer);

        bool isGrounded = (hitCenter.collider != null || hitLeft.collider != null || hitRight.collider != null);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }

    void GestionarMovimiento(float inputMovimiento)
    {
        rb.velocity = new Vector2(inputMovimiento * velocity, rb.velocity.y);
        if (inputMovimiento != 0)
    
            animator.SetBool("enMovimiento", true);
        else
            animator.SetBool("enMovimiento", false);
            
        
    }
}
