using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        //position.x += 0.01f;
        //position.y -= 0.01f;

        // Debug.Log("Tecla A pulsada: " + Input.GetKey(KeyCode.A));
        // Debug.Log("Tecla S pulsada: " + Input.GetKey(KeyCode.S));
        // Debug.Log("Tecla D pulsada: " + Input.GetKey(KeyCode.D));
        // Debug.Log("Tecla W pulsada: " + Input.GetKey(KeyCode.W));

        // if (Input.GetKey(KeyCode.A))
        //    position.x -= 0.01f;
        // if (Input.GetKey(KeyCode.D))
        //     position.x += 0.01f;
        // if (Input.GetKey(KeyCode.W))
        //     position.y += 0.01f;
        // if (Input.GetKey(KeyCode.S))
        //     position.y -= 0.01f;
        
        position.x = position.x + Input.GetAxis("Horizontal") * 0.01f;
        position.y = position.y + Input.GetAxis("Vertical") * 0.01f;
        transform.position = position;
    }
}
