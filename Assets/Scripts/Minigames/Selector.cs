using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public List<GameObject> scratchers = new List<GameObject>();
    private int currentPosition = 0;
    void Start()
    {
        currentPosition = 0;
        this.transform.position = scratchers[currentPosition].transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentPosition++;
            if (currentPosition > scratchers.Count - 1) {
                currentPosition = 0;
            }
            this.transform.position = scratchers[currentPosition].transform.position;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            currentPosition--;
            if (currentPosition < 0) {
                currentPosition = scratchers.Count - 1;
            }
            this.transform.position = scratchers[currentPosition].transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            scratchers[currentPosition].GetComponentInChildren<ScratcherController>().ScratchOff();
            GetComponentInParent<Lottery>().increaseCount(currentPosition);
        }
    }
}
