using System.Threading.Tasks;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public Animator animator;
    public float DestructionTimer = 5f;
    private bool isjugador = false;

    public AudioSource audioSource;
    public AudioClip sonidoRecoger;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playRecoger();
            animator.SetBool("isplayer", !isjugador);
            Destroy(gameObject, DestructionTimer);
        }
    }

    public void playRecoger()
    {
        audioSource.PlayOneShot(sonidoRecoger);
    }
  

    void Update()
    {
       
    }
}
