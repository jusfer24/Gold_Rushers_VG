using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPlatformerController : MonoBehaviour
{
    [Header("Configuracion de Movimiento")]
    public float moveSpeed = 8f;
    public float jumpForce = 15f;
    public float fuerzaRebote = 15f;

    [Header("Configuracion del Suelo (GroundCheck)")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;
    private bool isDead = false;
    private GameManagerR gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManagerR>();
    }

    void Update()
    {
        if (isDead) return;

        horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-0.05f, 0.05f, 0.05f);
        }
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        if (isDead) return;
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    public void RecibeDanio(Vector2 direccion, int cantDanio)
    {
        if (isDead) return;

        if (cantDanio > 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;

        if (gameManager != null)
        {
            gameManager.GameOver();
        }
    }
}