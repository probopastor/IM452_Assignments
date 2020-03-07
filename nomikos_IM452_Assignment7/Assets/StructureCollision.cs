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

    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        loseScreen.SetActive(false);
        takeDamage = true;
        invoker = new TornadoInputManagerInvoker();
        changeSize = new ChangeSize(playerScale);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Take Damage: " + takeDamage);
        //invoker.AddCommand(changeSize);
        //invoker.InvokeCommand();
        gameObjectLocalScale = gameObject.transform.localScale;
    }

    private void FixedUpdate()
    {
        if(counter >= damageTimer/0.02f)
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
            //Vector3 colliderLocalScale = other.transform.localScale;

            //if (colliderLocalScale.x <= gameObjectLocalScale.x + 0.5f)
            //{
            //    other.gameObject.SetActive(false);
            //    invoker.AddCommand(changeSize);
            //    invoker.InvokeCommand();
            //}
            if (other.GetComponent<Renderer>().bounds.size.x < gameObjectLocalScale.x + 15f)
            {
                Debug.Log(other.GetComponent<Renderer>().bounds.size.x);
                Debug.Log("my object scale: " + gameObjectLocalScale.x);

                other.gameObject.SetActive(false);
                invoker.AddCommand(changeSize);
                invoker.InvokeCommand();
            }
            else if(takeDamage)
            {
                Debug.Log(other.GetComponent<Renderer>().bounds.size.x);
                Debug.Log("my object scale: " + gameObjectLocalScale.x);

                invoker.InvokeUndoCommand();
                takeDamage = false;
                counter = 0;

                if(invoker.IsGameLost())
                {
                    loseScreen.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 0;
                }
            }
        }
    }
}
