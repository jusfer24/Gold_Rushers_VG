using System;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    private GameManagerS gameManagerS;
    public Animator animator;

    public AudioSource audioSource;
    public AudioClip sonidoRecoger;

    private void Start()
    {
        // Esta línea es obligatoria para que el código funcione y encuentre tu GameManagerS
        gameManagerS = FindFirstObjectByType<GameManagerS>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BluePlayer") || collision.gameObject.CompareTag("RedPlayer"))
        {
            playRecoger();
            animator.SetBool("isplayer", true);
           
            if (collision.gameObject.CompareTag("BluePlayer"))
            {
                gameManagerS.IncreaseScorePlayer1();
                Debug.Log("Tu mensaje aquí");
            }
            else if (collision.gameObject.CompareTag("RedPlayer"))
            {
                gameManagerS.IncreaseScorePlayer2();
                Debug.Log("Tu mensaje adas");
            }

            Destroy(gameObject);
        }
    }

    public void playRecoger()
    {
       audioSource.PlayOneShot(sonidoRecoger);
    }
}