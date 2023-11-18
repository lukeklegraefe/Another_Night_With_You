using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Lottery : MonoBehaviour
{
    public GameObject[] scratchers;
    public Sprite[] scratchIcons;
    public GameObject scratchPrefab;
    public Animator endAnimator;
    public Animator resultAnimator;
    public TextMeshProUGUI resultText;
    public bool isActive = true;
    public int numberScratched = 0;
    private int redScratched = 0;
    private int yellowScratched = 0;
    private int blueScratched = 0;

    private GameObject selector;

    public List<int> scratcherPositions = new List<int>();

    void Start()
    {
        selector = GetComponentInChildren<Selector>().gameObject;
        scratcherPositions = getRandomizedPositions();
        for (int i = 0; i < scratchers.Length; i++)
        {
            scratchers[i].GetComponent<ScratcherController>().SetIcon(scratchIcons[scratcherPositions[i]]);
            scratchers[i].GetComponent<ScratcherController>().SetIndex(scratcherPositions[i]);
        }
    }

    void Update()
    {
        if (!isActive) {
            Debug.Log("Setting inactive");
            gameObject.SetActive(isActive);
        }
    }

    private List<int> getRandomizedPositions() {
        List<int> result = new List<int>();
        List<int> orderedList = ShuffleList(new List<int> { 0, 1, 2 });

        List<int> crescent = new List<int>() { orderedList[0], orderedList[1] };
        crescent = ShuffleList(crescent);
        result.AddRange(crescent);
        List<int> gibbous = new List<int>() { orderedList[1], orderedList[0], orderedList[0] };
        gibbous = ShuffleList(gibbous);
        result.AddRange(gibbous);
        List<int> full = new List<int>() { orderedList[0], orderedList[1], orderedList[2], orderedList[0]};
        full = ShuffleList(full);
        result.AddRange(full);
        return result;
    }

    private List<int> ShuffleList(List<int> list) {
        for (int i = 0; i < list.Count; i++) {
            int temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }

    public void increaseCount(int type) {
        switch (type) {
            case 0:
                redScratched++;
                break;
            case 1:
                yellowScratched++;
                break;
            case 2:
                blueScratched++;
                break;
            default:
                break;
        }
        numberScratched++;
        if (redScratched > 0 && yellowScratched > 0 && blueScratched > 0) {
            Debug.Log("WINNER");
            resultText.SetText("WINNER");
            resultAnimator.SetTrigger("Win");
            selector.SetActive(false);
            Invoke("SetInactive", 3f);
        }
        else if (numberScratched > 3) {
            Debug.Log("LOSER");
            resultText.SetText("LOSER");
            resultAnimator.SetTrigger("Loss");
            selector.SetActive(false);
            Invoke("SetInactive", 2.8f);
        }
    }

    private void SetInactive() {
        endAnimator.SetTrigger("End");
        FindObjectOfType<Transition>().StartTransition();
    }

    private void LoadTown() {
        SceneManager.LoadScene(0);
    }
}
