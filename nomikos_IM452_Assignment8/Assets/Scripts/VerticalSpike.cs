﻿/*
* William Nomikos
* VerticalSpike.cs
* Assignment 8
* Subclass of SpikeSuperclass, handles behaviors of the vertical spike, which
* moves up and down. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSpike : SpikeSuperclass
{
    public float movementSpeed = 1f;
    public float verticalSpeed = 1f;

    private PlayerController player;

    public Transform currentPoint;
    public Transform[] points;

    private int pointSelection = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        pointSelection = 0;
        currentPoint = points[pointSelection];
    }

    // Update is called once per frame
    void Update()
    {
        PreformAction();
    }
    protected override void MoveSpike()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * verticalSpeed);

        if(transform.position == currentPoint.position)
        {
            pointSelection++;

            if(pointSelection >= points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
        }
    }

    protected override bool IsFirstDimension()
    {
        //if (player.isDimension1)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}

        return true;
    }
}
