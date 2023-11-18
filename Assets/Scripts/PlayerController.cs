using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int time = 0;
    private TextMeshProUGUI moneyText;
    public bool isTalking = false;
    public PauseMenu pauseMenu;

    private void Start() {
        pauseMenu = FindObjectOfType<PauseMenu>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 1) {
            pauseMenu = FindObjectOfType<PauseMenu>();
            if (pauseMenu.paused == true) {
                pauseMenu.Deactivate();
            } else {
                pauseMenu.Activate();
                GetComponent<PlayerMovement>().setDisabled(true);
            }
        }
    }

    public int GetTime() {
        return time;
    }

    public void AddTime() {
        time++;
    }

    public void LateDialogue() {
        StopAllCoroutines();
        StartCoroutine(LateDialogueRoutine());
    }

    IEnumerator LateDialogueRoutine() {
        isTalking = true;
        gameObject.GetComponent<PlayerMovement>().setDisabled(true);
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        yield return new WaitForSeconds(3.5f);
        FindObjectOfType<DialogueManager>().EndDialogue();
        gameObject.GetComponent<PlayerMovement>().setDisabled(false);
        isTalking = false;
    }
}
