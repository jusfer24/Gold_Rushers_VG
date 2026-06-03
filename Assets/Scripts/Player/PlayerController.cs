using System.ComponentModel;
using System.Collections; 
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public PlayerSoundController playerSoundController;

    [Header("Configuracion de Movimiento")]
    public float velocidad = 8f;   
    public float jumpForce = 15f;  
    public Animator animator;

    [Header("Configuracion del Suelo (GroundCheck)")]
    public Transform groundCheck;  
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
        if (!isDie)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * velocidad;
            animator.SetFloat("movement", horizontalInput * velocidad);

            if (horizontalInput < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (horizontalInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            Vector3 posicion = transform.position;
            transform.position = new Vector3(horizontalInput + posicion.x, posicion.y, posicion.z);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, groundLayer);
            isGrounded = hit.collider != null;

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                playerSoundController.playSaltar();
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }

            animator.SetBool("onground", isGrounded);
            animator.SetBool("isdiying", isDie);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * velocidad, rb.linearVelocity.y);
    }

    public void MorirPlayer()
    {
        StartCoroutine(IniciarMuerte());
    }

    private IEnumerator IniciarMuerte()
    {
        if (!isDie)
        {
            isDie = true;

            if (GameManagerS.instance != null)
            {
                animator.SetBool("isdiying", isDie);
                playerSoundController.playMorir();

                yield return new WaitForSeconds(2.5f);

                GameManagerS.instance.GameOver();
            }
        }
    }

    private void OnDrawGizmos()
    {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
            }
    }
}