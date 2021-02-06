using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrames_James : MonoBehaviour
{
    [SerializeField]float iFramesTime;
    private bool isInvincible = false;


    private void IFramesOff()    //Called when i-frames are over.
    {
        isInvincible = false;
    }


    public void StartIFramesTimer()    //Called by another script when i-frames should start.
    {
        isInvincible = true;
        Invoke(nameof(IFramesOff), iFramesTime);
    }


    public bool GetIsInvincible()    //Allows state of invicibility to be fetched externally.
    {
        return isInvincible;
    }
}