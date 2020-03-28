/*
* William Nomikos
* SpikeSuperclass.cs
* Assignment 8
* The spike super class, which holds a template method, concrete spike methods, abstract spike methods, and 
* the hook that alters spike behavior.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpikeSuperclass : MonoBehaviour
{
    private Vector2 initialScale;
    private bool performOnce = false;
    private PauseManager pauseManager;


    /// <summary>
    /// Template method, responsible for determining which methods a spike should run through.
    /// </summary>
    protected void PreformAction()
    {
        MoveSpike();
        
        if (!performOnce)
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

    /// <summary>
    /// Sets the initial scale of the spikes back to their original scale.
    /// </summary>
    protected void SetInitialScale()
    {
        initialScale = gameObject.transform.localScale;
    }



    /// <summary>
    /// Method is activated depending on the conditional output of the hook, IsFirstDimension. Handles pulsing the spike
    /// in and out of existence. 
    /// </summary>
    protected void PulseSpike()
    {
        float phi = (Time.time / 2.5f) * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi);
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

    //Concrete method responsible for losing the game upon the player interacting with a spike.
    protected void HurtPlayer()
    {
        pauseManager = FindObjectOfType<PauseManager>();
        pauseManager.LoseGame();
    }

    /// <summary>
    /// Abstract method to be implemented differently depending on the spike. Handles spike movement.
    /// </summary>
    protected abstract void MoveSpike();


    /// <summary>
    /// Hook, if output is false, spikes will pulsate in and out of existence due to the PulseSpike method. 
    /// Returns true by default to prevent unwanted behavior.
    /// </summary>
    /// <returns></returns>
    protected virtual bool IsFirstDimension()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HurtPlayer();
        }
    }
}
