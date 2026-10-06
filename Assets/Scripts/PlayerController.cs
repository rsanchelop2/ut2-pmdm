using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float velocity = 18f; 

    private bool puedeMoverse = true;

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
    }

    public void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        if (puedeMoverse) GestionarMovimiento(inputHorizontal);
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

        // Si presionamos saltar y estamos en el suelo, saltamos y activamos animación
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            animator.SetBool("salto", true);
        }
        
        // CORRECCIÓN: Si el personaje está en el suelo y NO está subiendo (velocidad y <= 0),
        // apagamos la animación de salto de manera segura.
        if (isGrounded && rb.velocity.y <= 0.1f)
        {
            animator.SetBool("salto", false);
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
        if (input > 0)
            transform.localScale = new Vector3(1,1,1);
        else if (input < 0)
            transform.localScale = new Vector3(-1,1,1);
    }

    void GestionarMovimiento(float inputMovimiento)
    {
        rb.velocity = new Vector2(inputMovimiento * velocity, rb.velocity.y);
        
        if (inputMovimiento != 0)
            animator.SetBool("enMovimiento", true);
        else
            animator.SetBool("enMovimiento", false);
    }

    public void DesactivarMovimiento(float duration)
    {
        StartCoroutine(DisableMovementCourtine(duration));
    }

    private IEnumerator DisableMovementCourtine(float duration)
    {
        puedeMoverse = false;
        yield return new WaitForSeconds(duration);
        puedeMoverse = true;
    }
}
