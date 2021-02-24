using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayTransition : MonoBehaviour
{
    public Button yourButton;
    public Animator anim;
    public Animator animSmoke;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        anim.Play("BossAwaken");
        StartCoroutine(WaitTime());
        //animSmoke.SetTrigger("Smoke");
        
    }
        

    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        animSmoke.SetTrigger("Smoke");
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }


}
