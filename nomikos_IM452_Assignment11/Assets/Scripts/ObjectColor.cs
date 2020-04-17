/*
* William Nomikos
* ObjectColor.cs
* Assignment 11
* Handles setting the objects Simon triggers to be a different
* color while Simon is on them.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    private SpriteRenderer rend;
    private Color originalColor;

    public void SetActiveColor(Color activeColor)
    {
        rend = GetComponent<SpriteRenderer>();
        originalColor = rend.color;
        rend.color = activeColor;
    }

    public void SetDeactiveColor()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = originalColor;
    }
}
