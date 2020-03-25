using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isDimension1;
    private float gravityDimension1 = 1f;
    private float gravityDimension2 = 1f;
    private bool canJump;

    public float jumpHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDimension1 = true;
        gravityDimension1 = rb.gravityScale;
        gravityDimension2 = -rb.gravityScale;

        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(canJump);

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(isDimension1)
            {
                isDimension1 = false;
            }
            else if(!isDimension1)
            {
                isDimension1 = true;
            }

            CheckDimension();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump)
            {
                //rb.AddForce(Vector2.up * jumpHeight);
                rb.velocity = Vector2.up * jumpHeight;
                canJump = false;
            }
        }
    }

    private void CheckDimension()
    {
        if (isDimension1)
        {
            rb.gravityScale = gravityDimension1;
        }           
        else if(!isDimension1)
        {
            rb.gravityScale = gravityDimension2;
        }

        gameObject.transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        jumpHeight = -jumpHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
}
