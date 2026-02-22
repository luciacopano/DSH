using UnityEngine;
using UnityEngine.InputSystem;
public class MovimientoBola : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;

    private Camera camara;
    private Vector3 posicioncamara;

    int premiosDestruidos = 0;

    int choquesPared = 0;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();


        camara = Camera.main;

        posicioncamara = camara.transform.position - transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si choca con un objeto con la etiqueta "Premio"
        if (collision.gameObject.CompareTag("Premio"))
        {
            Destroy(collision.gameObject); // Destruye el premio
            premiosDestruidos++; // Incrementa el contador
            Debug.Log("Premios destruidos: " + premiosDestruidos); 
        }
        // Si choca con un objeto con la etiqueta "Pared"
        else if (collision.gameObject.CompareTag("Pared"))
        {
            choquesPared++;
            Debug.Log("Vidas gastadas: " + choquesPared);
            if(choquesPared >= 3)
            {
                Destroy(gameObject);
            }
        }
    }
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float ejeY = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;

        Vector3 movimiento = new Vector3(horizontal, ejeY, vertical);

        rb.AddForce(movimiento * velocidad);


        camara.transform.position = transform.position + posicioncamara;
    }
}

