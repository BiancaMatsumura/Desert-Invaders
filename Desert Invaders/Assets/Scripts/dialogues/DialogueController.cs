using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public List<ScriptableDialogue> dialogues;
    public Text textContent;
    public GameObject dialoguePanel;
    public float timeActivePanel;
    public float typingSpeed;
    public AudioSource popUpAudio;
    public AudioSource typingAudio;

    void Start()
    {
        dialoguePanel.SetActive(false);
    }
    public void ShowDialogueByIndex(int index)
    {
        if (index >= 0 && index < dialogues.Count)
        {
            ShowDialogue(dialogues[index]);
        }
   
    }
    public void ShowDialogue(ScriptableDialogue dialogue)
    {
        
        StartCoroutine(TypeText(dialogue.message));
        dialoguePanel.SetActive(true); 
        popUpAudio.Play();
    }
    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }
    private IEnumerator TypeText(string text)
    {
        textContent.text = "";
        foreach (char letter in text.ToCharArray())
        {
            typingAudio.Play();
            textContent.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
        Invoke("HideDialogue", timeActivePanel);
    }
}
