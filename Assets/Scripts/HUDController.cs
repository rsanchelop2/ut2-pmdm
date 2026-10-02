using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;

    public TextMeshProUGUI monedas;

    void Update()
    {
        monedas.text = gameManager.Monedas.ToString();
    }
}
