using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryTelling : MonoBehaviour
{
    public Text dialogueText;
    private Queue<string> sentences;
    private Queue<Sprite> cutscenes;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject ContinueButton;
    public GameObject CutSceneBox;

    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
        cutscenes = new Queue<Sprite>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);
        sentences.Clear();
        cutscenes.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (Sprite cutscene in dialogue.cutscenes)
        {
            cutscenes.Enqueue(cutscene);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (cutscenes.Count == 0)
        {
            CutSceneBox.gameObject.SetActive(false);
        }
        else
        {
            Sprite cutscene = cutscenes.Dequeue();
            CutSceneBox.GetComponent<Image>().sprite = cutscene;
        }
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
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
