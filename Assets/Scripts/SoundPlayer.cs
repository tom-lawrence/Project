using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    // ---------------Boss-----------------
  void SwingFX()
    {
        SoundManager.PlaySound("BossSwingFX");
    }

    void MaceThrowFX()
    {
        SoundManager.PlaySound("MaceSwooshFX");
    }
    void BossStompFX()
    {
        SoundManager.PlaySound("ArrowFX");
    }
    void BossLaughFX()
    {
        SoundManager.PlaySound("BossLaughFX");
    }

    //---------------Player--------------
    void JumpFX()
    {
        SoundManager.PlaySound("PlayerJumpFX");
    }

    void LightAttackFX()
    {
        SoundManager.PlaySound("StabFX");
    } 
    
    void HeavyAttackFX()
    {
        SoundManager.PlaySound("SwingFX");
    }


}
