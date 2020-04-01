using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void ChasePlayer();
    void OnFire();
    void Stunned();

}
