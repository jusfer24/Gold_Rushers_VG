using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public PlayerSoundController playerSoundController;

    [Header("Controles del Jugador")]
    public KeyCode teclaIzquierda = KeyCode.A;
    public KeyCode teclaDerecha = KeyCode.D;
    public KeyCode teclaSalto = KeyCode.W;

    [Header("Configuracion de Movimiento")]
    public float velocidad = 8f;
    public float jumpForce = 15f;
    public Animator animator;

    [Header("Configuracion del Suelo (GroundCheck)")]
    public float longitudRaycast = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private bool isDie;
    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDie) return;

        horizontalInput = 0f;
        if (Input.GetKey(teclaIzquierda)) horizontalInput = -1f;
        if (Input.GetKey(teclaDerecha)) horizontalInput = 1f;

        //animator.SetFloat("movement", Mathf.Abs(horizontalInput * velocidad));

        if (horizontalInput < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (horizontalInput > 0) transform.localScale = new Vector3(1, 1, 1);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, groundLayer);
        isGrounded = hit.collider != null;

        if (Input.GetKeyDown(teclaSalto) && isGrounded)
        {
            playerSoundController.playSaltar();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        //animator.SetBool("onground", isGrounded);
    }

    void FixedUpdate()
    {
        if (isDie) return;
        rb.linearVelocity = new Vector2(horizontalInput * velocidad, rb.linearVelocity.y);
    }

    public void MorirPlayer()
    {
        isDie = true;
        rb.linearVelocity = Vector2.zero;
        //animator.SetBool("isdiying", true);
        playerSoundController.playMorir();
        GameManagerS.instance.PlayerDied(gameObject.tag);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}