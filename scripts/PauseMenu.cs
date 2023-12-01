using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPause;
    private bool pauseGame = false;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        if (!pauseGame)
        {
            pauseGame = true;
            Time.timeScale = 0f;
            menuPause.SetActive(true);

            gameManager.PauseMusic();
        }
    }

    public void Resume()
    {
        pauseGame = false;
        Time.timeScale = 1f;
        menuPause.SetActive(false);

        gameManager.ResumeMusic();
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
}