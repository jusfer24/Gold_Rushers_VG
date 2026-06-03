using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 4.0f;
    public float speed = 1.0f;

    public int puntosPorMuerte = 15;
    public int danioAlJugador = 100;

    private bool estaMuerto = false;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private GameManagerR gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = FindFirstObjectByType<GameManagerR>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }
    }

    void Update()
    {
        if (estaMuerto || player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            movement = new Vector2(direction.x, 0);

            if (movement.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                animator.SetFloat("caminar", direction.x);
            }
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                animator.SetFloat("caminar", direction.x);
            }
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (estaMuerto) return;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (estaMuerto) return;

        if (collision.CompareTag("Bala"))
        {
            gameManager.IncreaseScore();
            Morir();
            Destroy(collision.gameObject);
        }

    }

    private void OtorgarPuntos()
    {
        if (gameManager != null)
        {
            gameManager.IncreaseScore(puntosPorMuerte);
        }
    }

    private void Morir()
    {
        movement = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
        rb.simulated = false;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (estaMuerto) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direccionDanio = (collision.transform.position - transform.position).normalized;
            PlayerPlatformerController playerController = collision.gameObject.GetComponent<PlayerPlatformerController>();

            if (playerController != null)
            {
                playerController.RecibeDanio(direccionDanio, danioAlJugador);
            }
        }

        if (collision.gameObject.CompareTag("Muro"))
        {
            Morir();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public void CambiarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}