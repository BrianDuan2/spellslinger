using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryTelling : MonoBehaviour
{
    public Text dialogueText;
    private Queue<string> sentences;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject ContinueButton;

    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        YesButton.gameObject.SetActive(true);
        NoButton.gameObject.SetActive(true);
        ContinueButton.gameObject.SetActive(false);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
