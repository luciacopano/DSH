using UnityEngine;

public class GunControl : MonoBehaviour
{

    public GameObject BalaPreFab;
    public Transform PuntoDisparo;

    public float TiempoEntreDisparos = 0.5f;
    public float TiempoUltimoDisparo = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Disparar()
    {
        if (Time.time - TiempoUltimoDisparo >= TiempoEntreDisparos)
        {
            Instantiate(BalaPreFab, PuntoDisparo.position, PuntoDisparo.rotation);
            TiempoUltimoDisparo = Time.time;
        }
    }
}
