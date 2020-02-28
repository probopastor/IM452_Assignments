using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //enum ModeSwitching { Start, Acceleration }
    public Rigidbody2D ship;
    public float force = 0f;
    public float rotationAngle = 0f;

    public ProjectileCreator projectileCreator;

    public float startAmmunition = 50f;
    private float currentAmmunition;

    private string projectileType;

    private bool isCorn;
    private bool isPea;
    private bool isMelon;
    private bool isCoconut;

    private bool smallCreatorSet;
    private bool largeCreatorSet;

    public GameObject bullet;
    public float bulletSpeed = 10f;

    public float fireRate;
    float lastShot;

    //public AudioClip shootSound;

    private void Start()
    {
        projectileType = "Corn";
        projectileCreator = new SmallProjectileCreator();
        smallCreatorSet = true;
        largeCreatorSet = false;
        currentAmmunition = startAmmunition;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGunType();

        if((isCorn || isPea) && !smallCreatorSet)
        {
            projectileCreator = new SmallProjectileCreator();
            smallCreatorSet = true;
            largeCreatorSet = false;
        }
        else if((isMelon || isCoconut) && !largeCreatorSet)
        {
            projectileCreator = new LargeProjectileCreator();
            largeCreatorSet = true;
            smallCreatorSet = false;
        }

        //Basic Ship Controls
        if (Input.GetKey(KeyCode.W))
        {
            ship.AddForce(transform.right * force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ship.AddForce(-transform.right * force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationAngle);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            ShootBullet(projectileType);
        }

        //Ship wraps if it moves off of the map
        if (transform.position.x < -32.4f)
        {
            gameObject.transform.position = new Vector2((-transform.position.x), transform.position.y);
            gameObject.transform.position = new Vector2(transform.position.x - 0.25f, transform.position.y);
        }
        else if (transform.position.x > 32.4f)
        {
            gameObject.transform.position = new Vector2((-transform.position.x), transform.position.y);
            gameObject.transform.position = new Vector2(transform.position.x + 0.25f, transform.position.y);
        }
        else if (transform.position.y > 18.3f)
        {
            gameObject.transform.position = new Vector2(transform.position.x, (-transform.position.y));
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 0.25f);

        }
        else if (transform.position.y < -18.3f)
        {
            gameObject.transform.position = new Vector2(transform.position.x, (-transform.position.y));
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

        }
    }

    private void ChangeGunType()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            projectileType = "Corn";
            isCorn = true;
            isPea = false;
            isMelon = false;
            isCoconut = false;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            projectileType = "Pea";
            isCorn = false;
            isPea = true;
            isMelon = false;
            isCoconut = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            projectileType = "Melon";
            isCorn = false;
            isPea = false;
            isMelon = true;
            isCoconut = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            projectileType = "Coconut";
            isCorn = false;
            isPea = false;
            isMelon = false;
            isCoconut = true;
        }
    }

    //Shoots a bullet
    void ShootBullet(string projectileType)
    {
        //Limits fire rate of bullets
        //if (Time.time > fireRate + lastShot)
        //{
        //    var bulletClone = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
        //    Vector2 direction = transform.up;
        //    bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        //    lastShot = Time.time;

        //    //AudioSource.PlayClipAtPoint(shootSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        //}

        

        if(currentAmmunition > 0)
        {
            if (Time.time > fireRate + lastShot)
            {
                GameObject projectile = null;

                projectile = projectileCreator.CreateProjectilePrefab(projectileType);

                var projectileClone = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

                projectileCreator.AddProjectileScript(projectileClone, projectileType);

                Vector2 direction = transform.up;

                projectileClone.GetComponent<Projectiles>().ProjectileMovement(direction);

                lastShot = Time.time;

                //AudioSource.PlayClipAtPoint(shootSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
            }
        }

    }
}
