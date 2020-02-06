/*
* William Nomikos
* IObserver.cs
* Assignment 3
* This Interface gives classes that implemented it the ability to update data of
* all Observers in the game.
* 
* All Phantom enemies must be an observer. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void UpdateData(bool chasePlayer, float chaseSpeed, bool immuneToDamage, Color currentColor, float damageRate, AudioSource SoundEffectSource, AudioClip damageNoise);
}
