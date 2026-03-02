using UnityEngine;

public class Bala : MonoBehaviour
{

    public float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        float movimiento = speed * Time.fixedDeltaTime;
        transform.Translate(Vector3.up * movimiento);

    }
}
