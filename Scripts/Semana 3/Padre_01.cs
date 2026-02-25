using UnityEngine;
using System;

public class Padre_01 : MonoBehaviour
{
    public delegate void Padre01(int valor);
    public event Padre01 OnPulsado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pulsado");
            OnPulsado?.Invoke(3);
        }
    }
}
