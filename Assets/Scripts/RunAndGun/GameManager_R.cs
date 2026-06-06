using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerR : MonoBehaviour
{
    private int scoreP1_i = MainMenuController.DatosGlobales.puntajeAcumulado_B;
    private int scoreP2_i = MainMenuController.DatosGlobales.puntajeAcumulado_R;

    private int scoreP1;
    private int scoreP2;

    private int score;
    public TMP_Text scoreText;

    public TMP_Text scoreTextP1;
    public TMP_Text scoreTextP2;

    public GameObject GameOver_Panel;

    private bool player1Alive;
    private bool player2Alive;

    private void Awake()
    {
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

        GameOver_Panel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        GameOver_Panel.SetActive(true);
        Time.timeScale = 0f;
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

    public void PlayerDied(int playerID)
    {
        if (playerID == 1)
        {
            player1Alive = false;
        }
        else if (playerID == 2)
        {
            player2Alive = false;
        }

        if (!player1Alive && !player2Alive)
        {
            MainMenuController.DatosGlobales.puntajeAcumulado_B = scoreP1;
            MainMenuController.DatosGlobales.puntajeAcumulado_R = scoreP2;
            if(scoreP1 > scoreP2)
            {
                SceneManager.LoadScene("Winner_B");
            }
            else
            {
                SceneManager.LoadScene("Winner_R");
            }

            //GameOver();
        }
    }
}