using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void UpdateData(bool chasePlayer, float chaseSpeed, string tagName);
}
