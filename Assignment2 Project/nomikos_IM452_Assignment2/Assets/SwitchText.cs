using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwitchText : MonoBehaviour
{
    public Text switchText;
    private float count1 = 200f;
    private float countDepletionRate = 0.5f;
    private float count2 = 0;

    public Color incompleteColor;
    public Color completeColor;

    // Start is called before the first frame update
    void Start()
    {
        switchText.fontSize = 16;
        switchText.text = "Switch Timer: Not Ready";
        switchText.color = incompleteColor;

        count2 = count1;

    }

    // Update is called once per frame
    void Update()
    {
        count2 -= countDepletionRate;


        if (count2 <= 0)
        {
            switchText.text = "Switch Timer: Ready";
            switchText.color = completeColor;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                count2 = count1;
                switchText.text = "Switch Timer: Not Ready";
                switchText.color = incompleteColor;

            }
        }
    }
}
