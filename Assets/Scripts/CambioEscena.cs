using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public int numEscena;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(EsperarYCambiar(numEscena, 2f));
    }

    private IEnumerator EsperarYCambiar(int nombre, float tiempoDeEspera)
    {
        yield return new WaitForSeconds(tiempoDeEspera);
        SceneManager.LoadScene(nombre);
    }
}
