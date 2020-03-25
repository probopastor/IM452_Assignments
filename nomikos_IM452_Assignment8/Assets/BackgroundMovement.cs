using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float backgroundSpeed = 0f;
    public GameObject background;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-backgroundSpeed * Time.deltaTime, 0, 0);


        if (transform.position.x <= -20.94)
        {
            float halfWidth = gameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
            float otherHalfWidth = background.GetComponent<SpriteRenderer>().bounds.extents.x;

            float xPos = background.transform.position.x + halfWidth + otherHalfWidth;

            transform.position = new Vector3(xPos, background.transform.position.y, background.transform.position.z);
        }
    }
}
