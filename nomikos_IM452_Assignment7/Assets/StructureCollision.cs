using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureCollision : MonoBehaviour
{
    private TornadoInputManagerInvoker invoker;

    private Vector3 gameObjectLocalScale;

    private ICommand changeSize;
    public PlayerScale playerScale;

    // Start is called before the first frame update
    void Start()
    {
        invoker = new TornadoInputManagerInvoker();
        changeSize = new ChangeSize(playerScale);
    }

    // Update is called once per frame
    void Update()
    {
        //invoker.AddCommand(changeSize);
        //invoker.InvokeCommand();
        gameObjectLocalScale = gameObject.transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Structure"))
        {
            Vector3 colliderLocalScale = other.transform.localScale;

            if(colliderLocalScale.x <= gameObjectLocalScale.x + 0.5f)
            {
                other.gameObject.SetActive(false);
                invoker.AddCommand(changeSize);
                invoker.InvokeCommand();
            }
        }
    }
}
