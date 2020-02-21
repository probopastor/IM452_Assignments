using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Color clickedColor;
    public Color defaultColor;

    private Renderer buttonRend;
    private bool isClicked;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        buttonRend = gameObject.GetComponent<Renderer>();
        buttonRend.material.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButton()
    {
        if(!isClicked)
        {
            isClicked = true;
            buttonRend.material.color = clickedColor;
        }
        else if(isClicked)
        {
            isClicked = false;
            buttonRend.material.color = defaultColor;
        }
    }
}
