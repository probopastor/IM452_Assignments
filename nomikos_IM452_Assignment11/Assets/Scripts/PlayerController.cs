/*
* William Nomikos
* PlayerController.cs
* Assignment 11
* Handles player movement, and handles determining if the player successfully copied 
* Simon's movements. 
*/

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
    private bool canMove;
    private SpriteRenderer rend;

    public Color normalColor;
    public Color deactiveColor;

    private PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        index = 0;
        int centerOfListIndex = tracks.Count / 2;
        transform.position = new Vector3(tracks[centerOfListIndex].transform.position.x, transform.position.y, transform.position.z);
        currentIndex = centerOfListIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            rend.color = normalColor;

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentIndex + 1 <= tracks.Count - 1)
                {
                    currentIndex = currentIndex + 1;
                    transform.position = new Vector3(tracks[currentIndex].transform.position.x, transform.position.y, transform.position.z);
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentIndex - 1 >= 0)
                {
                    currentIndex = currentIndex - 1;
                    transform.position = new Vector3(tracks[currentIndex].transform.position.x, transform.position.y, transform.position.z);
                }
            }
        }
        else if(!canMove)
        {
            rend.color = deactiveColor;
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
    public void CanPlayerMove(bool move)
    {
        canMove = move;
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
                }
                else
                {
                    roundComplete = false;
                    index++;
                }
            }
            else
            {
                pauseManager = FindObjectOfType<PauseManager>();
                pauseManager.SetGameLost();
            }
        }
    }
}
