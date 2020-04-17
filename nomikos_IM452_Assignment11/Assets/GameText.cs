using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameText : MonoBehaviour
{
    public GameObject playerText;
    public GameObject simonText;

    public void EnableText(bool isSimonsTurn)
    {
        if(isSimonsTurn)
        {
            simonText.SetActive(true);
            playerText.SetActive(false);
        }
        else if(!isSimonsTurn)
        {
            simonText.SetActive(false);
            playerText.SetActive(true);
        }
    }
}
