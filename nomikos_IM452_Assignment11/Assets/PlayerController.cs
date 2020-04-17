using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> tracks = new List<GameObject>();
    private int currentIndex = 0;

    private List<GameObject> objects = new List<GameObject>();

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        int centerOfListIndex = tracks.Count / 2;
        transform.position = new Vector3(tracks[centerOfListIndex].transform.position.x, transform.position.y, transform.position.z);
        currentIndex = centerOfListIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(currentIndex + 1 <= tracks.Count - 1)
            {
                currentIndex = currentIndex + 1;
                transform.position = new Vector3(tracks[currentIndex].transform.position.x, transform.position.y, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(currentIndex - 1 >= 0)
            {
                currentIndex = currentIndex - 1;
                transform.position = new Vector3(tracks[currentIndex].transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    public bool CheckWaveCompletion()
    {
        if(objects.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ObjectsToTouch(List<GameObject> objectOrder)
    {
        objects = objectOrder;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(objects.Count != 0)
        {
            if (objects[index] != null)
            {
                if (collision.gameObject.tag == objects[index].tag)
                {
                    objects.Remove(objects[index]);
                    index++;
                }
                else if (collision.gameObject.tag != objects[index].tag)
                {
                    Debug.Log("GameLost");
                    Time.timeScale = 0;
                }
            }
        }
        else
        {
            Debug.Log("Wait For Simon! ");
        }
    }
}
