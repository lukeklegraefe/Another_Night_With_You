using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueObject;
    public bool typingMessage = false;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        sentences.Clear();
        dialogueObject.SetActive(true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(null);
    }

    public void DisplayNextSentence(NPCController npc)
    {
        if (sentences.Count == 0)
        {
            if (npc != null) {
                npc.isTalking = false;
            }
            typingMessage = false;
            EndDialogue();
            return;
        }

        Debug.Log(sentences.Peek());

        StopAllCoroutines();

        if (typingMessage)
        {
            dialogueText.maxVisibleCharacters = dialogueText.text.ToCharArray().Length;
            typingMessage = false;
        } else
        {
            string sentence = sentences.Dequeue();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    public IEnumerator TypeSentence(string sentence)
    {
        typingMessage = true;
        dialogueText.SetText(sentence);

        int totalVisibleCharacters = dialogueText.text.ToCharArray().Length;
        int charCount = dialogueText.text.ToCharArray().Length;
        int counter = 0;
        for (int i = 0; i <= charCount; i++)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            dialogueText.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                yield return new WaitForSeconds(0.4f);
            }
            counter += 1;

            yield return new WaitForSeconds(0.05f);
        }
        typingMessage = false;
    }

    public void EndDialogue()
    {
        sentences.Clear();
        dialogueObject.SetActive(false);
    }
}
