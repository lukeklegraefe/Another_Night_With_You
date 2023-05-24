using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchCard : MonoBehaviour
{
    public GameObject maskPrefab;
    private bool isPressed = false;

    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 50;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (isPressed)
        {
            GameObject maskSprite = Instantiate(maskPrefab, mousePos, Quaternion.identity);
            maskSprite.transform.parent = gameObject.transform;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }
    }
}
