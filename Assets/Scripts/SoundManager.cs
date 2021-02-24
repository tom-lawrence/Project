using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerDashSound, playerDeathSound, playerJumpSound, playerPainSound, stabSound, swingSound, arrowSound, bossDeathSound, bossLaughSound, bossMoveSound, bossPainSound, bossSwingSound, maceSwooshSound;
    static AudioSource audioSrc;

    void Start()
    {
        playerDashSound = Resources.Load<AudioClip>("PlayerDashFX");
        playerDeathSound = Resources.Load<AudioClip>("PlayerDeathFX");
        playerJumpSound = Resources.Load<AudioClip>("PlayerJumpFX");
        playerPainSound = Resources.Load<AudioClip>("PlayerPainFX");
        stabSound = Resources.Load<AudioClip>("StabFX");
        swingSound = Resources.Load<AudioClip>("SwingFX");
        arrowSound = Resources.Load<AudioClip>("ArrowFX");
        bossDeathSound = Resources.Load<AudioClip>("BossDeathFX");
        bossLaughSound = Resources.Load<AudioClip>("BossLaughFX");
        bossMoveSound = Resources.Load<AudioClip>("BossMoveFX");
        bossPainSound = Resources.Load<AudioClip>("BossPainFX");
        bossSwingSound = Resources.Load<AudioClip>("BossSwingFX");
        maceSwooshSound = Resources.Load<AudioClip>("MaceSwooshFX");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {

        switch (clip)
        {
            case "PlayerDashFX":
                audioSrc.PlayOneShot(playerDashSound);
                break;

            case "PlayerDeathFX":
                audioSrc.PlayOneShot(playerDeathSound);
                break;

            case "PlayerJumpFX":
                audioSrc.PlayOneShot(playerJumpSound, 0.3f);
                break;
            
            case "PlayerPainFX":
                audioSrc.PlayOneShot(playerPainSound);
                break;
            
            case "StabFX":
                audioSrc.PlayOneShot(stabSound);
                break;
            
            case "SwingFX":
                audioSrc.PlayOneShot(swingSound);
                break;
                
            case "ArrowFX":
                audioSrc.PlayOneShot(arrowSound);
                break;
            
            case "BossDeathFX":
                audioSrc.PlayOneShot(bossDeathSound);
                break;

            case "BossLaughFX":
                audioSrc.PlayOneShot(bossLaughSound);
                break;

            case "BossMoveFX":
                audioSrc.PlayOneShot(bossMoveSound);
                break;
                
            case "BossPainFX":
                audioSrc.PlayOneShot(bossPainSound);
                break;
                
            case "BossSwingFX":
                audioSrc.PlayOneShot(bossSwingSound);
                break;
                   
            case "MaceSwooshFX":
                audioSrc.PlayOneShot(maceSwooshSound);
                break;
                
        }
    }
}
