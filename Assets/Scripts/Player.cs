using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;

    public float gravity = -9.8f;
    public float strength = 5f;

    public KeyCode jumpKey = KeyCode.Space;
    public int playerID = 1;

    public AudioClip jumpSound;

    private AudioSource audioSource;
    private GameManagerR gameManager;

    private bool isDead = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindAnyObjectByType<GameManagerR>();
    }

    private void OnEnable()
    {
        isDead = false;

        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;

        direction = Vector3.zero;
    }

    private void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(jumpKey))
        {
            direction = Vector3.up * strength;

            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Obstacle"))
        {
            isDead = true;

            gameManager.PlayerDied(playerID);

            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Scoring"))
        {
            if (playerID == 1)
            {
                gameManager.IncreaseScorePlayer1();
            }
            else
            {
                gameManager.IncreaseScorePlayer2();
            }
        }
    }
}