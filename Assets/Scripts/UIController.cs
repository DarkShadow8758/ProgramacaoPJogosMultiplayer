using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpItens;
    private int itensQtd;
    void Update()
    {
        
    }

    public void IncreaseItens()
    {
        itensQtd++;
        tmpItens.text = "Itens Count: " + itensQtd.ToString();
    }
}
