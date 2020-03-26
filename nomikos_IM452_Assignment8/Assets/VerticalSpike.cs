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
    public override void MoveSpike()
    {
        //transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0, 0);

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

    public override bool IsFirstDimension()
    {
        if (player.isDimension1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
