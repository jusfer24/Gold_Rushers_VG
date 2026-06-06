using UnityEngine;

public class BadPlataforms : MonoBehaviour
{
    private GameManagerS gamemaagerS;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BluePlayer") || collision.gameObject.CompareTag("RedPlayer"))
        {
            // Extraemos el script del jugador con el que chocamos
            PlayerController jugador = collision.gameObject.GetComponent<PlayerController>();

            // Activamos su función de morir
            jugador.MorirPlayer();
        }
    }
}
