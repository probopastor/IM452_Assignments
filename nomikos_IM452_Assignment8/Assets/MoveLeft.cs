using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float movementSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -20.94)
        {
            Destroy(gameObject);
        }
    }
}
