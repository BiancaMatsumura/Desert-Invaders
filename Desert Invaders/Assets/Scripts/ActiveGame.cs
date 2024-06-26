using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveGame : MonoBehaviour
{
    public UIController controller;
    public string fase1 = "Intro";
    public string credits = "victoryScene";
    private Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == fase1)
        {
            controller.Load("fase1");
        }
        if (currentScene.name == credits)
        {
            controller.Load("credits");
        }


    }

 
}
