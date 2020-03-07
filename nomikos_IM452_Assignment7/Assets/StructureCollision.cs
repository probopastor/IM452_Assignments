using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureCollision : MonoBehaviour
{
    private TornadoInputManagerInvoker invoker;

    private Vector3 gameObjectLocalScale;

    private ICommand changeSize;
    public PlayerScale playerScale;

    public int damageTimer = 1;
    private int counter = 0;
    private bool takeDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        takeDamage = true;
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

    private void FixedUpdate()
    {
        if(counter == damageTimer/0.02f)
        {
            takeDamage = true;
            counter = 0;
        }

        counter++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Structure"))
        {
            Vector3 colliderLocalScale = other.transform.localScale;

            if (colliderLocalScale.x <= gameObjectLocalScale.x + 0.5f)
            {
                other.gameObject.SetActive(false);
                invoker.AddCommand(changeSize);
                invoker.InvokeCommand();
            }
            else if(takeDamage)
            {
                invoker.InvokeUndoCommand();
                takeDamage = false;
            }
        }
    }
}
