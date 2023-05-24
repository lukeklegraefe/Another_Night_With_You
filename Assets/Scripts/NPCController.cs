using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public bool inRange = false;
    public bool isTalking = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (!isTalking)
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                isTalking = true;
            } else
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence(this);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isTalking)
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
        inRange = false;
    }
}
