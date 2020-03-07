/*
* William Nomikos
* ICommand.cs
* Assignment 7
* Command interface that is invoked by the invoker.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();

    void Undo();
}
