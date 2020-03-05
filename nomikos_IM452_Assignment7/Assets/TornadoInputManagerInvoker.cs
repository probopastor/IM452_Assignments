using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoInputManagerInvoker : MonoBehaviour
{
    public PlayerScale playerScale;
    private ICommand changeSize;

    // Start is called before the first frame update
    void Start()
    {
        changeSize = new ChangeSize(playerScale);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            changeSize.Execute();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            changeSize.Undo();
        }
    }
}
