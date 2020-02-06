using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void UpdateData(bool chasePlayer, float chaseSpeed, bool immuneToDamage, Color currentColor, float damageRate, AudioSource SoundEffectSource, AudioClip damageNoise);
}
