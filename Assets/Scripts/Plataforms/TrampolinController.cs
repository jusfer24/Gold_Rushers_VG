using UnityEngine;

public class TrampolinController : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip sonidoTrampoline;
    private bool isjump = false;

    public float fuerzaImpulso = 15f;

    void Start()
    {
        
    }
    void Update()
    {
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isjump = true;
            PlayTrampolin();
            animator.SetBool("isjumping", isjump);

            Rigidbody2D rbJugador = collision.GetComponent<Rigidbody2D>();
            if (rbJugador != null)
            {
                rbJugador.linearVelocity = new Vector2(rbJugador.linearVelocity.x, 0f);
                rbJugador.AddForce(Vector2.up * fuerzaImpulso, ForceMode2D.Impulse);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isjump = false; 
            animator.SetBool("isjumping", isjump); 
        }
    }

    public void PlayTrampolin()
    {
        audioSource.PlayOneShot(sonidoTrampoline);
    }
}
