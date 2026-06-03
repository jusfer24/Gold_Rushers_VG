using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;

    public float gravity = -9.8f;
    public float strength = 5f;

    // Se ejecuta cada vez que el jugador se activa
    private void OnEnable()
    {
        // Reinicia la posición vertical
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;

        // Reinicia el movimiento
        direction = Vector3.zero;
    }

    private void Update()
    {
        // Salto con espacio o clic
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // Salto en móvil con touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        // Aplicar gravedad
        direction.y += gravity * Time.deltaTime;

        // Mover jugador
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManagerR>().GameOver();
        }
        else if (other.CompareTag("Scoring"))
        {
            FindObjectOfType<GameManagerR>().IncreaseScore();
        }
    }
}