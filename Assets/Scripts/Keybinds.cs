using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keybinds : MonoBehaviour
{

    private Dictionary<string, KeyCode > keys = new Dictionary<string, KeyCode>();

    public Text jump, dash, left, right;

    private GameObject currentKey;




    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Jump", KeyCode.W);
        keys.Add("Dash", KeyCode.E);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);



        jump.text = keys["Jump"].ToString();
        dash.text = keys["Dash"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();

    }

    // Update is called once per frame
    void Update()
    {
     
        




    }


    void OnGUI()
    {
        if (currentKey !=null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}
