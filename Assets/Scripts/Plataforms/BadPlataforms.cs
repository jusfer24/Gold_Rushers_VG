using UnityEngine;

public class BadPlataforms : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().MorirPlayer();
        }
    }
}
