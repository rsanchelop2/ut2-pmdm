using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int monedas;
    public int Monedas { get { return monedas; }}

    public void SumarMonedas(int monedasASumar)
    {
        monedas += monedasASumar;
        Debug.Log("Monedas totales: " + monedas);
    }
}
