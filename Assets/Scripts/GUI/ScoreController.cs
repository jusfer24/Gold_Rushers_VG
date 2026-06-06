using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    private int score;
    private int score_r;

    public TMP_Text txt_scoreb;
    public TMP_Text txt_scorer;

    void Start()
    {
        score = MainMenuController.DatosGlobales.puntajeAcumulado_B;
        score_r = MainMenuController.DatosGlobales.puntajeAcumulado_R;

        txt_scoreb.SetText(score.ToString());
        txt_scorer.SetText(score_r.ToString());

        if (!MainMenuController.DatosGlobales.escenaDestino.Equals("Winner_B") && !MainMenuController.DatosGlobales.escenaDestino.Equals("Winner_R"))
        {
            StartCoroutine(CambiarDeEscena());
        }
    }

    private IEnumerator CambiarDeEscena()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(MainMenuController.DatosGlobales.escenaDestino);
    }
}