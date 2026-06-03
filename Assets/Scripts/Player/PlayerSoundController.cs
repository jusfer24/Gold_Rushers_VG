using UnityEngine;

public class PlayerSoundController : MonoBehaviour 
{
    public AudioSource audioSource;
    public AudioClip sonidoSaltar;
    public AudioClip sonidoMorir;
    public AudioClip sonidoCorrer;

    public void playSaltar()
    {
        audioSource.PlayOneShot(sonidoSaltar);
    }

    public void playMorir()
    {
        audioSource.PlayOneShot(sonidoMorir);
    }

    public void playCorrer()
    {
        audioSource.PlayOneShot(sonidoCorrer);
    }
}

