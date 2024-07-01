using System.Collections;
using System.Collections.Generic;
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

    public bool isTyping = false;

    private void Start()
    {
        isTyping = false; ;
    }
    public void ShowDialogueByIndex(int index)
    {
        if (index >= 0 && index < dialogues.Count && !isTyping)
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
        isTyping = false;
    }
    private IEnumerator TypeText(string text)
    {
        isTyping = true;
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
