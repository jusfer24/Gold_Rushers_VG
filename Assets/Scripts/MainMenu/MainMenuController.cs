using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void CambiarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }

    public static class DatosGlobales
    {
        public static int puntajeAcumulado_B = 0;
        public static int puntajeAcumulado_R = 0;
        public static string escenaDestino = "SkyJump";
    }
}
