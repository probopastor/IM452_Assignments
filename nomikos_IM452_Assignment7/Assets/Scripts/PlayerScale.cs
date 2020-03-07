using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    public float scaleChangeValue = 0.1f;

    public Vector3 GetCurrentScale()
    {
        return gameObject.transform.localScale;
    }

    public void ChangeScale()
    {
        Vector3 objectLocalScale = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(objectLocalScale.x + scaleChangeValue, objectLocalScale.y, objectLocalScale.z + scaleChangeValue);
    }
}
