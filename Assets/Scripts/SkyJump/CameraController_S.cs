using UnityEngine;

public class CameraController_S : MonoBehaviour
{
    public Transform objetivo;
    public float velocidadCamara = 0.125f;
    public Vector3 desplazamiento;

    // Usaremos esta variable para recordar dónde pusiste la cámara al inicio
    private float posicionXFija;
    private float posicionZFija;

    void Start()
    {
        posicionXFija = transform.position.x;
        posicionZFija = transform.position.z;

        // Opcional: Acomodar la cámara en Y al inicio
        if (objetivo != null)
        {
            transform.position = new Vector3(posicionXFija, objetivo.position.y + desplazamiento.y, posicionZFija);
        }
    }

    private void LateUpdate()
    {
        if (objetivo == null) return;
        Vector3 posicionDeseada = new Vector3(posicionXFija, objetivo.position.y + desplazamiento.y, posicionZFija);

        // Hacemos la transición suave hacia esa nueva posición
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara);

        // Aplicamos el movimiento
        transform.position = posicionSuavizada;
    }
}