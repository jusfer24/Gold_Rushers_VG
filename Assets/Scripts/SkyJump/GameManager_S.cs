using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerS : MonoBehaviour
{
    public static GameManagerS instance;

    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public Button reiniciarButton;
    public Button menuButton;
    public Button pauseButton;
    public TextMeshProUGUI RecordText;

    private bool gameOverActivo = false;

    [Header("Monedas GUI")]
    public int monedas = 0;
    public TextMeshProUGUI textoMonedas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
           Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameObject.SetActive(true);
        }

        if(reiniciarButton != null)
        {
            reiniciarButton.onClick.AddListener(ReiniciarEscena);
        }

        if(menuButton != null)
        {
            menuButton.onClick.AddListener(IrAlMenu);
        }

        CargarMonedas();
        ActualizarUIMonedas();
    }

    void Update()
    {
        if (gameOverActivo)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReiniciarEscena();
            }

            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M))
            {
                IrAlMenu();
            }
        }
    }

    public void AgregarMonedas(int cantidad)
    {
        monedas += cantidad;
        ActualizarUIMonedas();
        GuardarMonedas();
    }

    public void ActualizarUIMonedas()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "x " + monedas.ToString();
        }
    }

    public void GuardarMonedas()
    {
        PlayerPrefs.SetInt("Monedas", monedas);
        PlayerPrefs.Save();
    }

    public void CargarMonedas()
    {
        monedas = PlayerPrefs.GetInt("Monedas", 0);
    }

    public void GameOver()
    {
        if (gameOverActivo)
        {
            return;
        }

        gameOverActivo=true;

        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (pauseButton != null)
        {
            pauseButton.gameObject.SetActive(false);
        }

        if (RecordText != null)
        {
            RecordText.gameObject.SetActive(false);
        }

        //if(gameOverText != null)
        //{
        //    gameOverText.text = "GAME OVER \n \nR - Reiniciar\nESC - Menu Principal";
        //}
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("MainMenu");
    }
}


