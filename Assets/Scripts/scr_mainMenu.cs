using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scr_mainMenu : MonoBehaviour
{

    public GameObject painelCreditos;
    public GameObject painelMain;
    public AudioSource som;

    public Button b1;
    public Button b2;
    public Button b3;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && painelCreditos.active ==  true)
        {
            FechaCreditos();
        }
    }

    public void BotaoPlay()
    {
        StartCoroutine(Play(0.75f));
    }

    public void AbreCreditos()
    {
        som.Play();
        painelMain.SetActive(false);
        painelCreditos.SetActive(true);
    }

    public void FechaCreditos()
    {
        som.Play();
        painelMain.SetActive(true);
        painelCreditos.SetActive(false);
    }

    public void Quit()
    {
        som.Play();
        Application.Quit();
    }

    IEnumerator Play(float tempo)
    {
        b1.interactable = false;
        b2.interactable = false;
        b3.interactable = false;
        som.Play();
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadSceneAsync("game");
    }
}
