using UnityEngine;

public class MovimientoDiamante : MonoBehaviour
{
    public float velocidad = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidad * Time.deltaTime, 0f, 0f);
    }

}
