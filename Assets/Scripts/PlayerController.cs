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

    [Header("Configuración de Raycasts")]
    public float rayLength = 0.5f;
    // Distancia desde el centro del personaje hacia los lados para los rayos de los bordes
    public float sideOffset = 0.4f; 

    public float velocity = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float inputMovimiento = Input.GetAxis("Horizontal");

        gestionarGiro(inputMovimiento);
        rb.velocity = new Vector2(inputMovimiento * velocity, rb.velocity.y);
        gestionarSalto();

        // Posiciones de origen para los tres rayos (Centro, Izquierda, Derecha)
        Vector2 originCenter = transform.position;
        Vector2 originLeft = new Vector2(transform.position.x - sideOffset, transform.position.y);
        Vector2 originRight = new Vector2(transform.position.x + sideOffset, transform.position.y);

        // Lanzamos los 3 Raycasts hacia abajo
        RaycastHit2D hitCenter = Physics2D.Raycast(originCenter, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(originLeft, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(originRight, Vector2.down, rayLength, groundLayer);

        // Si cualquiera de los 3 rayos toca el suelo, el personaje está en el suelo
        bool isGrounded = (hitCenter.collider != null || hitLeft.collider != null || hitRight.collider != null);

        // Saltar si se presiona el botón y estamos en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }

    void FixedUpdate() 
    {
        // Movimiento horizontal (Corregido: usamos hVelocity en lugar de jumpforce)
        float inputHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * inputHorizontal * hVelocity);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ultraJump"))
        {
            rb.gravityScale = rb.gravityScale * 2;
        }
    }

    // Dibuja las líneas en el editor para que puedas calibrar las distancias visualmente
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        // Rayo centro
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
        
        // Rayo izquierda
        Vector3 leftOrigin = transform.position + Vector3.left * sideOffset;
        Gizmos.DrawLine(leftOrigin, leftOrigin + Vector3.down * rayLength);
        
        // Rayo derecha
        Vector3 rightOrigin = transform.position + Vector3.right * sideOffset;
        Gizmos.DrawLine(rightOrigin, rightOrigin + Vector3.down * rayLength);
    }

    void gestionarGiro(float inputMovimiento)
    {
        if (inputMovimiento > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        } else if (inputMovimiento < 0){
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    void gestionarSalto()
    {
        
    }
}