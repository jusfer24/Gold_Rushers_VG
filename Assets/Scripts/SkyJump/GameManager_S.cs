using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerS : MonoBehaviour
{
    public static GameManagerS instance;
    private int scoreP1_i = MainMenuController.DatosGlobales.puntajeAcumulado_B;
    private int scoreP2_i = MainMenuController.DatosGlobales.puntajeAcumulado_R;

    private int scoreP1;
    private int scoreP2;

    private int score;

    public TMP_Text scoreText;

    public TMP_Text scoreTextP1;
    public TMP_Text scoreTextP2;

    private bool player1Alive;
    private bool player2Alive;

    private void Awake()
    {
        // ESTO ES VITAL: Asignar la instancia para que los demás scripts la encuentren
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        player1Alive = true;
        player2Alive = true;

        scoreP1 = scoreP1_i;
        scoreP2 = scoreP2_i;

        scoreTextP1.text = scoreP1.ToString();
        scoreTextP2.text = scoreP2.ToString();

        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScorePlayer1()
    {
        scoreP1++;
        scoreTextP1.text = scoreP1.ToString();
    }

    public void IncreaseScorePlayer2()
    {
        scoreP2++;
        scoreTextP2.text = scoreP2.ToString();
    }

    public void IncreaseScore(int amount = 1)
    {
        score += amount;
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void GameOver(){


    }
    public void PlayerDied(string tagJugador)
    {
        if (tagJugador == "BluePlayer")
        {
            player1Alive = false;
            Debug.Log("a");
        }
        else if (tagJugador == "RedPlayer")
        {
            player2Alive = false;
            Debug.Log("as");
        }

        if (!player1Alive && !player2Alive)
        {
            Debug.Log("asa");
            MainMenuController.DatosGlobales.puntajeAcumulado_B = scoreP1;
            MainMenuController.DatosGlobales.puntajeAcumulado_R = scoreP2;
            MainMenuController.DatosGlobales.escenaDestino = "FlappyBird";
            SceneManager.LoadScene("Intermade");
        }
    }
}