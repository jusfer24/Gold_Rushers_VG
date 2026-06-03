using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class NewRecordController : MonoBehaviour
{
    public Animator animator;
    public GameObject winimg;
    private bool iswin = false;
    public float tiempoRestante = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.CompareTag("Player") && !iswin)
            {
                iswin = true; 
                StartCoroutine(SecuenciaDeVictoria());
            }

        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
    private IEnumerator SecuenciaDeVictoria()
    {
        animator.SetBool("iswinning", iswin);
        yield return new WaitForSeconds(tiempoRestante);

  
        winimg.SetActive(true);
        Time.timeScale = 0; 

        Debug.Log("¡Juego terminado!");
    }
}
