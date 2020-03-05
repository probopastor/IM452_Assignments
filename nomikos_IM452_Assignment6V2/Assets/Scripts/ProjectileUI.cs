/*
* William Nomikos
* ProjectileUI.cs
* Assignment 6
* Handles the bottom bar in-game UI for which fruit will be
* used as a projectile in the cannon.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUI : MonoBehaviour
{
    public GameObject cornSelectedIcon;
    public GameObject strawberrySelectedIcon;
    public GameObject melonSelectedIcon;
    public GameObject coconutSelectedIcon;

    private ShootProjectile projectileGun;

    private bool cornSelected;
    private bool strawberrySelected;
    private bool melonSelected;
    private bool coconutSelected;

    // Start is called before the first frame update
    void Start()
    {
        cornSelectedIcon.SetActive(true);
        strawberrySelectedIcon.SetActive(false);
        melonSelectedIcon.SetActive(false);
        coconutSelectedIcon.SetActive(false);

        projectileGun = GameObject.FindObjectOfType<ShootProjectile>();
    }

    // Update is called once per frame
    void Update()
    {
        if(projectileGun.isCorn && !cornSelected)
        {
            cornSelectedIcon.SetActive(true);
            strawberrySelectedIcon.SetActive(false);
            melonSelectedIcon.SetActive(false);
            coconutSelectedIcon.SetActive(false);

            cornSelected = true;
            strawberrySelected = false;
            melonSelected = false;
            coconutSelected = false;
        }
        else if (projectileGun.isStrawberry && !strawberrySelected)
        {
            cornSelectedIcon.SetActive(false);
            strawberrySelectedIcon.SetActive(true);
            melonSelectedIcon.SetActive(false);
            coconutSelectedIcon.SetActive(false);

            cornSelected = false;
            strawberrySelected = true;
            melonSelected = false;
            coconutSelected = false;
        }
        else if (projectileGun.isMelon && !melonSelected)
        {
            cornSelectedIcon.SetActive(false);
            strawberrySelectedIcon.SetActive(false);
            melonSelectedIcon.SetActive(true);
            coconutSelectedIcon.SetActive(false);

            cornSelected = false;
            strawberrySelected = false;
            melonSelected = true;
            coconutSelected = false;
        }
        else if (projectileGun.isCoconut && !coconutSelected)
        {
            cornSelectedIcon.SetActive(false);
            strawberrySelectedIcon.SetActive(false);
            melonSelectedIcon.SetActive(false);
            coconutSelectedIcon.SetActive(true);

            cornSelected = false;
            strawberrySelected = false;
            melonSelected = false;
            coconutSelected = true;
        }
    }
}
