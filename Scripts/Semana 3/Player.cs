using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera camara;
    public float Velocidad = 5f;
    public Gun_Control gunControl;

    private Rigidbody rb;

    void Start()
    {
        gunControl = GetComponent<Gun_Control>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Mira hacia donde apunta el mouse
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            Vector3 lookPos = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);
            transform.LookAt(lookPos);
        }

        // Disparo
        if (Input.GetMouseButtonDown(0))
        {
            gunControl.Disparar();
        }
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0, moveZ).normalized;

        // Mueve usando Rigidbody.velocity
        rb.linearVelocity = moveDir * Velocidad + new Vector3(0, rb.linearVelocity.y, 0);
    }
}