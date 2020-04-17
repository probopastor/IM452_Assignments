using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> tracks = new List<GameObject>();
    private int currentIndex = 0;

    public List<string> objectsEncountered = new List<string>();
    private int index = 0;

    private bool roundComplete;

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
        Debug.Log(objectsEncountered.Count);
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

    public bool PlayerFinished()
    {
        return roundComplete;
    }

    public void ResetIndex()
    {
        index = 0;
        roundComplete = false;
    }

    public void ObjectsToTouch(List<string> objectOrder)
    {
        if(objectsEncountered.Count > 0)
        {
            //objectsEncountered.Clear();
            objectsEncountered = new List<string>();
        }

        objectsEncountered = objectOrder;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(objectsEncountered.Count > 0)
        {
            if (collision.gameObject.tag == objectsEncountered[index])
            {
                

                if (index >= objectsEncountered.Count - 1)
                {
                    roundComplete = true;
                    Debug.Log("Round Over");
                }
                else
                {
                    roundComplete = false;
                    index++;
                }
            }
        }
    }
}
