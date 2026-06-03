using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManagerR : MonoBehaviour
{
    private int score_save;
    private int score;
    public TMP_Text scoreText;
    public GameObject GameOver_Panel;
    public GameObject player;

    public void Awake(){
        Application.targetFrameRate = 60;
    }

    public void Play(){
        score = 0;
        scoreText.text = score.ToString();
        GameOver_Panel.SetActive(false);

        Time.timeScale = 1f;
        player.SetActive(true);
    }

    public void GameOver(){
        GameOver_Panel.SetActive(true);
        Time.timeScale = 0f;
        player.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore(int amount = 1)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
