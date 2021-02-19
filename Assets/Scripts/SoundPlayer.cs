using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
  void SwingFX()
    {
        SoundManager.PlaySound("BossSwingFX");
    }

    void MaceThrowFX()
    {
        SoundManager.PlaySound("MaceSwooshFX");
    }
    
    void LightAttackFX()
    {
        SoundManager.PlaySound("StabFX");
    } 
    
    void HeavyAttackFX()
    {
        SoundManager.PlaySound("SwingFX");
    }

    void JumpFX()
    {
        SoundManager.PlaySound("PlayerJumpFX");
    }

}
