using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratcherController : MonoBehaviour
{
    public SpriteRenderer scratchIcon;
    public Animator scratchAnimation;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ScratchOff()
    {
        scratchAnimation.SetTrigger("trigger");
    }

    public void SetIcon(Sprite sprite)
    {
        this.scratchIcon.sprite = sprite;
    }
}
