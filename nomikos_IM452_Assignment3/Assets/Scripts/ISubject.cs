/*
* William Nomikos
* ISubject.cs
* Assignment 3
* Interface that allows scripts to implement methods to
* register, remove and notify observers. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
    
}
