using UnityEngine;

public class FireController : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip sonidoFire;
    private bool ispress = false;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ispress = true;
            PlayFire();
            animator.SetBool("ispressing", ispress);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ispress = false;
            animator.SetBool("ispressing", ispress);
        }
    }

    public void PlayFire()
    {
        audioSource.PlayOneShot(sonidoFire);
    }
}
