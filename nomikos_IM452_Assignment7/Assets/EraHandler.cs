using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraHandler : MonoBehaviour
{
    public GameObject[] objects;
    public int timePerEra = 10;

    public int era = 0;
    public int maxEra = 2;

    private int doOnceIndex = 0;
    private bool doOnce = false;

    private int counter = 0;
    private TornadoInputManagerInvoker invoker;
    private ICommand changeEra;

    // Start is called before the first frame update
    void Start()
    {
        invoker = new TornadoInputManagerInvoker();
        changeEra = new ChangeEra(this);
    }

    void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == era && !doOnce)
            {
                objects[i].SetActive(true);
                doOnce = true;
                doOnceIndex = i;
            }
            else if(i != doOnceIndex)
            {
                objects[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter++;

        if(counter >= timePerEra/0.02f)
        {
            invoker.AddCommand(changeEra);
            invoker.InvokeCommand();

            counter = 0;
        }
    }

    public int GetCurrentEra()
    {
        return era;
    }

    public void ChangeEra()
    {
        era++;
        if(era > maxEra)
        {
            era = maxEra;
        }
        else
        {
            doOnce = false;
        }
    }
}
