using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDashEffect : MonoBehaviour
{
    [SerializeField] float time;

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
