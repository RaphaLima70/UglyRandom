using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scr_gameManager : MonoBehaviour
{

    public AudioSource somMorte;
    public AudioSource somPontuando;
    public AudioSource somVidaUp;

    public int pontuacao;
    public int highScore;
    public float tempoDecorrido;

    public int contador;
    public int contadorDif;

    public float multiVelocidade;

    public Text pontuacaoTxt;
    public Text highScoreTxt;

    public GameObject painelPause;


    void Start()
    {
        multiVelocidade = 1;
        if (PlayerPrefs.HasKey("highscore"))
        {
            highScore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highScore = 0;
        }      
    }

    private void Update()
    {
        pontuacaoTxt.text = "Score: " + pontuacao;
        highScoreTxt.text = "Highscore: " + highScore;

        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }

        if (contador > 9)
        {
            contador = 0;
            somVidaUp.Play();
        }       
        if(contadorDif > 10)
        {
            contadorDif = 0;
            multiVelocidade += 0.17f;
        }
    }

    public void MarcaPonto()
    {
        contador++;
        contadorDif++;
        pontuacao++;
        somPontuando.Play();
        if(pontuacao >= highScore)
        {
            highScore = pontuacao;
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 0)
        {
            painelPause.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            painelPause.SetActive(true);
            Time.timeScale = 0;
        }   
    }

    public void Quit()
    {
        SceneManager.LoadScene("menu");
    }

    public IEnumerator Morte(float tempo)
    {
        somMorte.Play();
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene("game");
    }
}
