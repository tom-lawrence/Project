using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrames : MonoBehaviour
{
    [SerializeField]float I_FRAMES_TIME;
    private bool isInvincible = false;


    private void IFramesOff()    //Called when i-frames are over.
    {
        isInvincible = false;
    }


    public void StartIFramesTimer()    //Called by another script when i-frames should start.
    {
        isInvincible = true;
        Invoke(nameof(IFramesOff), I_FRAMES_TIME);
    }


    public bool GetIsInvincible()    //Allows state of invicibility to be fetched externally.
    {
        return isInvincible;
    }
}