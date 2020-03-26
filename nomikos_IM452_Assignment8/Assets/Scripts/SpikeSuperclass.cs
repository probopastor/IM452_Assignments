﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpikeSuperclass : MonoBehaviour
{
    public void PreformAction()
    {
        MoveSpike();

        if(!IsFirstDimension())
        {
            ShootSpike();
        }
    }

    public void ShootSpike()
    {
        //shoot spike projectile's here
    }

    public void HurtPlayer()
    {
        //Lose Game Here
    }

    public abstract void MoveSpike();

    public virtual bool IsFirstDimension()
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
