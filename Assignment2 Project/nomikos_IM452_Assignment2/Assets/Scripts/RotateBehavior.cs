/*
* William Nomikos
* RotateRight.cs
* Assignment 2
* Script is the "has a" component for platforms that rotate in the right direction. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehavior : MonoBehaviour, IMovementType
{
    
    public float rotationSpeed = 0f;
    private IEnumerator rotationCoroutine;
    private bool doOnce;


    private void Update()
    {
        if(!doOnce)
        {
            doOnce = true;
            MovePattern();
        }
    }

    public void MovePattern()
    {
        rotationCoroutine = Rotation(rotationSpeed);
        StartCoroutine(rotationCoroutine);
    }

    public IEnumerator Rotation(float rotationSpeed)
    {
        transform.Rotate(0, 0, rotationSpeed);
        yield return new WaitForSeconds(0.001f);

        rotationCoroutine = Rotation(rotationSpeed);
        StartCoroutine(rotationCoroutine);
    }
}
