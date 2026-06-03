using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausarJuego : MonoBehaviour
{
    public GameManagerS Manager;
    public GameObject menuPausa;
    public bool juegoPausado = false;

    public Image btn_sound;
    public Sprite btn_sound_on;
    public Sprite btn_sound_off;

    public Image btn_pause;
    public Sprite btn_pause_on;
    public Sprite btn_pause_off;

    public AudioSource audioBG;

    private bool isMuted = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Manager.gameOverPanel.activeSelf)
            {
                if (juegoPausado)
                {
                    Reanudar();
                }
                else
                {
                    Pausar();
                }
            }
        }
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
        btn_pause.sprite = btn_pause_on;
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
        btn_pause.sprite = btn_pause_off;
    }

    public void Sonido()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            btn_sound.sprite = btn_sound_off;
            audioBG.Pause();
        }
        else
        {
            btn_sound.sprite = btn_sound_on;
            audioBG.Play();
        }
    }

    public void Volver()
    {
        Reanudar();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
