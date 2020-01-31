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
    
    [SerializeField] private float rotationSpeed = 0f;
    private IEnumerator rotationCoroutine;

    public void MovePattern()
    {
        rotationCoroutine = Rotation(rotationSpeed);
        StartCoroutine(rotationCoroutine);
    }

    public IEnumerator Rotation(float rotationSpeed)
    {
        transform.Rotate(rotationSpeed, 0, 0);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(rotationCoroutine);
    }
}
