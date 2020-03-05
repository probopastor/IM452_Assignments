using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public Vector3 GetCurrentScale()
    {
        return gameObject.transform.localScale;
    }

    public void ChangeScale()
    {
        Vector3 objectLocalScale = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(objectLocalScale.x + 0.5f, objectLocalScale.y + 0.5f, objectLocalScale.z + 0.5f);
    }
}
