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
    public GameObject winScreen;

    public GameObject eraCheck;

    private GameObject[] lastEraObjects;
    private int enabledCheck = 0;
    //private int stillActiveCheck = 0;

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
        gameObjectLocalScale = gameObject.transform.localScale;
        //stillActiveCheck = lastEraObjects.Length;

        if (eraCheck.GetComponent<EraHandler>().era >= 3)
        {
            lastEraObjects = GameObject.FindGameObjectsWithTag("Structure");

            for(int i = 0; i < lastEraObjects.Length; i++)
            {
                if(lastEraObjects[i].activeSelf)
                {
                    Debug.Log("Last Era Active Objects " + lastEraObjects[i]);
                    enabledCheck++;
                }
                else
                {
                    enabledCheck = 0;
                }
            }
            if (enabledCheck <= 0)
            {
                WinGame();
            }

            enabledCheck = 0;
        }
        else if(eraCheck.GetComponent<EraHandler>().era < 3)
        {
            lastEraObjects = null;

            enabledCheck = 0;
            //stillActiveCheck = 0;
        }


        Debug.Log(enabledCheck);
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

    private void WinGame()
    {
        winScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}
