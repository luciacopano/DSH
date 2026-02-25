using UnityEngine;

public class Padre_00 : MonoBehaviour
{
    public GameObject Hijo;
    private Material materialHijo;

    private Color colorHijo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        materialHijo = Hijo.GetComponent<Renderer>().material;
        colorHijo = materialHijo.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (materialHijo.color == colorHijo)
            {
                materialHijo.color = Color.blue;
            }
            else
            {
                materialHijo.color = colorHijo;
            }
        }
    }
}
