using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehavior : MonoBehaviour
{
    private ObjectPooler objectPooler;

    public GameObject slowProjectiles;
    public GameObject fastProjectiles;
    public GameObject flamethrowerProjectile;

    public int firstAttackSize = 10;
    public int secondAttackSize = 10;
    public int thirdAttackSize = 10;
    public int fourthAttackSize = 10;

    public int attackIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.instance;

        StartCoroutine(AttackChooser());
    }

    private IEnumerator AttackChooser()
    {
        attackIndex = Random.Range(0, 4);

        if(attackIndex == 0)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(FirstAttack());
        }
        else if(attackIndex == 1)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(SecondAttack());
        }
        else if(attackIndex == 2)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(ThirdAttack());
        }
        else if(attackIndex == 3)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(FourthAttack());
        }

        yield return new WaitForEndOfFrame();
    }

    private IEnumerator FirstAttack()
    {
        for (int i = 0; i < firstAttackSize; i++)
        {
            objectPooler.SpawnFromPool("NormalProjectile", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }

        NormalProjectile[] normalProjectiles = FindObjectsOfType<NormalProjectile>();


        for (int i = 0; i < normalProjectiles.Length; i++)
        {
            objectPooler.ReturnObjectToPool("NormalProjectile", normalProjectiles[i].gameObject);
        }

        StartCoroutine(AttackChooser());
    }

    private IEnumerator SecondAttack()
    {
        for (int i = 0; i < secondAttackSize; i++)
        {
            objectPooler.SpawnFromPool("FastProjectile", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }

        FastProjectile[] fastProjectiles = FindObjectsOfType<FastProjectile>();


        for (int i = 0; i < fastProjectiles.Length; i++)
        {
            objectPooler.ReturnObjectToPool("FastProjectile", fastProjectiles[i].gameObject);
        }

        StartCoroutine(AttackChooser());
    }

    private IEnumerator ThirdAttack()
    {
        for (int i = 0; i < thirdAttackSize; i++)
        {
            objectPooler.SpawnFromPool("FlameProjectile", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }

        FlamethrowerProjectile[] FlameProjectiles = FindObjectsOfType<FlamethrowerProjectile>();


        for (int i = 0; i < FlameProjectiles.Length; i++)
        {
            objectPooler.ReturnObjectToPool("NormalProjectile", FlameProjectiles[i].gameObject);
        }

        StartCoroutine(AttackChooser());
    }

    private IEnumerator FourthAttack()
    {
        for (int i = 0; i < fourthAttackSize; i++)
        {
            objectPooler.SpawnFromPool("NormalProjectile", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            objectPooler.SpawnFromPool("FastProjectile", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }

        NormalProjectile[] normalProjectiles = FindObjectsOfType<NormalProjectile>();
        FastProjectile[] fastProjectiles = FindObjectsOfType<FastProjectile>();


        for (int i = 0; i < normalProjectiles.Length; i++)
        {
            objectPooler.ReturnObjectToPool("NormalProjectile", normalProjectiles[i].gameObject);
        }

        for (int i = 0; i < fastProjectiles.Length; i++)
        {
            objectPooler.ReturnObjectToPool("NormalProjectile", normalProjectiles[i].gameObject);
        }

        StartCoroutine(AttackChooser());
    }
}
