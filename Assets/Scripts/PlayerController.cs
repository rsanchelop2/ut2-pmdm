using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    public float hVelocity = 10f;

    int choques = 0;
    public float velocity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void FixedUpdate() {
        float inputHorizontal = Input.GetAxis("Horizontal");
        //rigidBody2D.velocity = new Vector2(inputHorizontal * hVelocity, rigidBody2D.velocity.y);
        rigidBody2D.AddForce(Vector2.right * inputHorizontal * hVelocity);
        
    }

    void onCollisionEnter2D(Collision2D other){
        Debug.Log("Colision con: " + other.gameObject.name);
        choques++;
        if (choques == 2){
            Debug.Log("Has ganado");
        }
    }
}
