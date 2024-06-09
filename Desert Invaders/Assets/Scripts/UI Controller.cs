using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject victoryPanel;
    public GameObject gameOverPanel;
    public AudioSource audioPopUp;

    public Text counter;

    public Animator transitionAnim;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(pausePanel.activeSelf)
            {
                Resume();
                audioPopUp.Play();
            }
            else
            {
                Pause();
                audioPopUp.Play();
            }
        }
        
    }

    public void Transition (string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene (string sceneName)
    {
        transitionAnim.SetTrigger("start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    public void Load(string SceneName) 
    {
        Transition(SceneName);
        Time.timeScale = 1f;
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart(string sceneName)
    {
        Transition(sceneName);
        Time.timeScale = 1f;
    }
}
