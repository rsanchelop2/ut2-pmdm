using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int monedas;
    public int vidasJugador;
    private int vidasTotales = 3;
    public int VidasTotales {get { return vidasTotales;}}
    public int VidasJugador {get { return vidasJugador;}}
    public int Monedas { get { return monedas; }}

    public Image[] corazones;
    public Sprite corazonLleno;
    public Sprite corazonVacio;

    void Start()
    {
        vidasJugador = vidasTotales;
        ActualizarCorazones();
    }


    public void SumarMonedas(int monedasASumar)
    {
        monedas += monedasASumar;
        Debug.Log("Monedas totales: " + monedas);
    }

    public void QuitarVidaJugador()
    {
        vidasJugador--;
        ActualizarCorazones();
        if (vidasJugador <= 0)
        {
            Debug.Log("Jugador muerto");
        }
    }

    void ActualizarCorazones()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < vidasJugador)
                corazones[i].sprite = corazonLleno;
            else
                corazones[i].sprite = corazonVacio;
        }
    }
}
