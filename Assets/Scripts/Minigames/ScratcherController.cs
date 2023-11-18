using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratcherController : MonoBehaviour
{
    public SpriteRenderer scratchIcon;
    public Animator scratchAnimation;
    private bool scratched = false;
    public int index;
    void Start() {
        
    }

    void Update() {
        
    }

    public bool GetState() {
        return scratched;
    }

    public void ScratchOff() {
        scratchAnimation.SetTrigger("trigger");
        scratched = true;
    }

    public void SetIcon(Sprite sprite) {
        this.scratchIcon.sprite = sprite;
    }

    public void SetIndex(int index) {
        this.index = index;
    }

    public int GetIndex() {
        return this.index;
    }
}
