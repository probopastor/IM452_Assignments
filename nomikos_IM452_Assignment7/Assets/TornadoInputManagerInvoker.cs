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
    // Update is called once per frame
    //void Update()
    ////{
    ////    if(Input.GetKeyDown(KeyCode.A))
    ////    {
    ////        //changeSize.Execute();
    ////        AddCommand(changeSize);
    ////        InvokeCommand();

    ////        DisplayCommands();
    ////    }

    ////    if(Input.GetKeyDown(KeyCode.Q))
    ////    {
    ////        //changeSize.Undo();
    ////        //AddCommand(changeSize);
    ////        InvokeUndoCommand();
    ////        commandStack.Pop();
    ////        DisplayCommands();
    ////    }

    //    if(Input.GetKeyDown(KeyCode.Alpha0))
    //    {
    //        //commandStack.Pop();
    //        Debug.Log("Command popped: " + commandStack.Pop());
    //    }
    //}

    public void AddCommand(ICommand command)
    {
        commandStack.Push(command);
    }

    public void DisplayCommands()
    {
        Debug.Log("----- List of Commands in Remote Control -----\n");

        foreach (ICommand command in commandStack)
        {
            Debug.Log("Command: " + command + "\n");
        }
    }

    public void InvokeCommand()
    {
        commandStack.Peek().Execute();
    }

    public void InvokeUndoCommand()
    {
        //if (commandStack.Count != 0)
        //{
        //    commandStack.Peek().Undo();

        //}
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

