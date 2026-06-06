using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController_S : MonoBehaviour
{
    public float velocidadSubida = 2.0f;
    public float limiteY = 20f;

    public Color colorFondoInicial = Color.blue;
    public Color colorFondoFinal = Color.black;

    private Camera camara;
    private float posicionYInicial;

    void Start()
    {
        camara = GetComponent<Camera>();
        posicionYInicial = transform.position.y;

        camara.clearFlags = CameraClearFlags.SolidColor;
        camara.backgroundColor = colorFondoInicial;
    }

    void LateUpdate()
    {
        if (transform.position.y < limiteY)
        {
            transform.position += Vector3.up * velocidadSubida * Time.deltaTime;

            float progreso = (transform.position.y - posicionYInicial) / (limiteY - posicionYInicial);
            camara.backgroundColor = Color.Lerp(colorFondoInicial, colorFondoFinal, progreso);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, limiteY, transform.position.z);
            camara.backgroundColor = colorFondoFinal;
        }
    }
}