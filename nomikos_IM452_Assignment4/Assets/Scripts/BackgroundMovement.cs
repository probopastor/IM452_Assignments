using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float backgroundSpeed = 0f;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-backgroundSpeed * Time.deltaTime, 0, 0);


        if(transform.position.x <= -22)
        {
            float halfWidth = gameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
            float otherHalfWidth = background.GetComponent<SpriteRenderer>().bounds.extents.x;

            float xPos = background.transform.position.x + halfWidth + otherHalfWidth;

            transform.position = new Vector3(xPos, background.transform.position.y);
        }
    }
}
