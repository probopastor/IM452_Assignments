using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEra : ICommand
{
    private EraHandler eraHandler;
    Stack<int> eraHistory;

    // Start is called before the first frame update
    public ChangeEra(EraHandler era)
    {
        this.eraHandler = era;

        eraHistory = new Stack<int>();
    }

    public void Execute()
    {
        eraHistory.Push(eraHandler.GetCurrentEra());
        eraHandler.ChangeEra();
    }

    public void Undo()
    {
        if(eraHistory.Count != 0)
        {
            eraHandler.era = eraHistory.Pop();
        }
    }
}
