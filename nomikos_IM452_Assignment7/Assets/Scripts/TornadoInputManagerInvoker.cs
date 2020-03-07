/*
* William Nomikos
* TornadoInputManagerInvoker.cs
* Assignment 7
* Invoker for all tornado commands, commands are stored here in a stack and invoked to
* be executed or undone.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoInputManagerInvoker
{
    public PlayerScale playerScale;
    private ICommand changeSize;

    private Stack<ICommand> commandStack;

    bool loseGame = false;

    public TornadoInputManagerInvoker()
    {
        commandStack = new Stack<ICommand>();

        changeSize = new ChangeSize(playerScale);
    }
    public void AddCommand(ICommand command)
    {
        commandStack.Push(command);
    }

    public void InvokeCommand()
    {
        commandStack.Peek().Execute();
    }

    public void InvokeUndoCommand()
    {
        if(commandStack.Count != 0)
        {
            commandStack.Peek().Undo();
            commandStack.Pop();
        }
        else
        {
            loseGame = true;
        }
    }

    public bool IsGameLost()
    {
        return loseGame;
    }
}

