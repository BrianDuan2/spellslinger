using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject StartButton;
    public GameObject SkipButton;

    public void TriggerDialogue ()
    {
        StartButton.gameObject.SetActive(false);
        SkipButton.gameObject.SetActive(false);
        FindObjectOfType<StoryTelling>().StartDialogue(dialogue);
    }
}
