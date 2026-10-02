using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaController : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarMonedas(valor);
            Destroy(gameObject);
        }
    }
}
