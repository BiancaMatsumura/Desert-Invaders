using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueController controller;

    public string fase1 = "fase1";
    public string fase2 = "fase2";
    public string fase3 = "fase3";
    public string finalBoss = "finalBoss";

    private Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == fase1)
        {
            StartCoroutine(Fase1());
        }
        else if (currentScene.name == fase2)
        {
            controller.ShowDialogueByIndex(1);
        }
        else if (currentScene.name == fase3)
        {
            controller.ShowDialogueByIndex(2);
        }
        else if (currentScene.name == finalBoss)
        {
            controller.ShowDialogueByIndex(3);
        }

    }
    
   private IEnumerator Fase1()
    {

        yield return new WaitForSeconds(3);
        controller.ShowDialogueByIndex(0);
    }
}
