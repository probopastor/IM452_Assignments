using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpObstacle : MonoBehaviour
{
    public float destructionTime = 35f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destructionTime);
    }
}
