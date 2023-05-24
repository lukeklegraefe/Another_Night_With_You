using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class Lottery : MonoBehaviour
{
    public GameObject[] scratchers;
    public Sprite[] scratchIcons;
    public GameObject scratchPrefab;
    public bool isActive = true;
    public int numberScratched = 0;
    private int redScratched = 0;
    private int yellowScratched = 0;
    private int blueScratched = 0;

    void Start()
    {
        List<int> scratcherFormation = getRandomizedPositions();
        FindObjectOfType<PlayerMovement>().setDisabled(true);
        for (int i = 0; i < scratchers.Length; i++)
        {
            scratchers[i].GetComponent<ScratcherController>().SetIcon(scratchIcons[scratcherFormation[i]]);
        }
    }

    void Update()
    {
        if (!isActive) {
            Debug.Log("Setting inactive");
            gameObject.SetActive(isActive);
            FindObjectOfType<PlayerMovement>().setDisabled(false);
        }
    }

    private List<int> getRandomizedPositions() {
        System.Random rand = new System.Random();

        List<int> orderedList = new List<int>();
        orderedList = ShuffleList(new List<int> { 0, 1, 2 });
        
        foreach (int i in orderedList) {
            Debug.Log(i.ToString());
        }

        List<int> crescent = new List<int>() { orderedList[0], orderedList[1] };
        crescent = ShuffleList(crescent);
        List<int> gibbous = new List<int>() { orderedList[1], orderedList[0], orderedList[2] };
        gibbous = ShuffleList(gibbous);
        List<int> full = new List<int>() { orderedList[0], orderedList[1], orderedList[2], orderedList[0]};
        full = ShuffleList(full);
        crescent.AddRange(gibbous);
        crescent.AddRange(full);
        return crescent;
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
        if (numberScratched > 3) {
            //isActive = false;
        }
    }
}
