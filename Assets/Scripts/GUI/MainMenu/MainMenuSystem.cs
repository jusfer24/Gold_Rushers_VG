using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSystem : MonoBehaviour
{
    public Image  btn_sound;
    public Sprite btn_sound_on;
    public Sprite btn_sound_off;

    public GameObject RecordPanel;

    public AudioSource audioBG;

    private bool isMuted = false;

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    public void Record()
    {
        RecordPanel.SetActive(true);
    }

    public void Atras()
    {
        RecordPanel.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
