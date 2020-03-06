using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoInputManagerInvoker : MonoBehaviour
{
    public PlayerScale playerScale;
    private ICommand changeSize;

    Dictionary<string, ICommand> commands;
    private Stack<ICommand> commandStack;

    // Start is called before the first frame update
    void Start()
    {
        commandStack = new Stack<ICommand>();

        changeSize = new ChangeSize(playerScale);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //changeSize.Execute();
            AddCommand(changeSize);
            InvokeCommand();

            DisplayCommands();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            //changeSize.Undo();
            //AddCommand(changeSize);
            InvokeUndoCommand();
            commandStack.Pop();
            DisplayCommands();
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            //commandStack.Pop();
            Debug.Log("Command popped: " + commandStack.Pop());
        }
    }

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
        if (commandStack.Count != 0)
        {
            commandStack.Peek().Undo();

        }
        else
        {
            Debug.Log("You tried to undo, but there are no more commands to undo.");
        }
    }

}

