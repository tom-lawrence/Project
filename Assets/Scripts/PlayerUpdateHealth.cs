using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpdateHealth : MonoBehaviour
{
    [SerializeField] GameObject playerSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerSlider.GetComponent<PlayerSlider>().SetPlayerHealth(GetComponent<Health>().GetHP());
    }
}
