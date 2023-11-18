using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public List<GameObject> scratchers = new List<GameObject>();
    private int currentPosition = 0;
    private int currentSpace = 0;
    private int maxSize = 2;
    private int minSize = 0;
    void Start()
    {
        currentPosition = 0;
        this.transform.position = scratchers[currentPosition].transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            currentPosition++;
            if (currentPosition > maxSize - 1) {
                currentPosition = minSize;
            }
            this.transform.position = scratchers[currentPosition].transform.position;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            currentPosition--;
            if (currentPosition < minSize) {
                currentPosition = maxSize - 1;
            }
            this.transform.position = scratchers[currentPosition].transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !scratchers[currentPosition].GetComponentInChildren<ScratcherController>().GetState()) {
            scratchers[currentPosition].GetComponentInChildren<ScratcherController>().ScratchOff();
            GetComponentInParent<Lottery>().increaseCount(scratchers[currentPosition].GetComponentInChildren<ScratcherController>().GetIndex());
            currentSpace++;
            AdjustSpace(currentSpace);
        }
    }

    private void AdjustSpace(int currentSpace) {
        switch (currentSpace) {
            case 1:
                minSize = 2;
                maxSize = 5;
                currentPosition = 2;
                this.transform.position = scratchers[currentPosition].transform.position;
                break;
            case 2:
                minSize = 5;
                maxSize = 9;
                currentPosition = 5;
                this.transform.position = scratchers[currentPosition].transform.position;
                break;
        }
    }
}
