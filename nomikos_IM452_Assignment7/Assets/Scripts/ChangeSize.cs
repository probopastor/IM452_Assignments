using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : ICommand
{
    private PlayerScale playerScale;

    Stack<Vector3> scaleHistory;

    public ChangeSize(PlayerScale scaleObject)
    {
        this.playerScale = scaleObject;
        scaleHistory = new Stack<Vector3>();
    }

    public void Execute()
    {
        scaleHistory.Push(playerScale.GetCurrentScale());
        playerScale.ChangeScale();
    }

    public void Undo()
    {
        if(scaleHistory != null)
        {
            playerScale.transform.localScale = scaleHistory.Pop();
        }
    }
}
