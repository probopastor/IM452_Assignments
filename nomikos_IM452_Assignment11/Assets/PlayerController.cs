using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> tracks = new List<GameObject>();
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
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
}
