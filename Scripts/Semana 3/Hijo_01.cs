using UnityEngine;

public class Hijo_01 : MonoBehaviour
{
    public Padre_01 padre;

    Color colorOriginal;
    private void CambiarColor(int valor)
    {
        Debug.Log("Valor recibido: " + valor);
        Renderer renderer = GetComponent<Renderer>();
        if (renderer.material.color == colorOriginal)
        {
            renderer.material.color = Color.red;
        }
        else
        {
            renderer.material.color = colorOriginal;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        padre.OnPulsado += CambiarColor;
        colorOriginal = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
