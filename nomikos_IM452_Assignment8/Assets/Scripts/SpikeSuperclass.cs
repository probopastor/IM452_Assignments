using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpikeSuperclass : MonoBehaviour
{
    private Vector2 initialScale;
    private bool performOnce = false;

    protected void PreformAction()
    {
        MoveSpike();

        if(!performOnce)
        {
            SetInitialScale();
            performOnce = true;
        }

        if (!IsFirstDimension())
        {
            PulseSpike();
        }
        else if(IsFirstDimension())
        {
            gameObject.transform.localScale = initialScale;
        }
    }

    protected void SetInitialScale()
    {
        initialScale = gameObject.transform.localScale;
    }

    protected void PulseSpike()
    {
        float phi = (Time.time / 5) * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5f + 0.5f;
        float newScale = amplitude;

        float maxScale = 0.06f;
        float minScale = 0f;

        if (newScale > maxScale)
        {
            newScale = maxScale;
        }

        if (newScale < minScale)
        {
            newScale = minScale;
        }

        gameObject.transform.localScale = new Vector3(newScale, newScale, gameObject.transform.localScale.z);
    }

    protected void HurtPlayer()
    {
        Debug.Log("Player Hurt");
        //Lose Game Here
    }

    protected abstract void MoveSpike();

    protected virtual bool IsFirstDimension()
    {
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HurtPlayer();
        }
    }
}
