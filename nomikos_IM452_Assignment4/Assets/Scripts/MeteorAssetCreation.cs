using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAssetCreation : MonoBehaviour
{
    public MeteorController myMeteor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DenseDebris"))
        {
            this.myMeteor = gameObject.AddComponent<DenseDebris>();
            UpdateMeteor();
        }

        if(collision.CompareTag("EmissiveAcceleration"))
        {
            this.myMeteor = gameObject.AddComponent<EmissiveAcceleration>();
            UpdateMeteor();
        }

        if (collision.CompareTag("MaterialRetraction"))
        {
            this.myMeteor = gameObject.AddComponent<MaterialRetraction>();
            UpdateMeteor();
        }
    }

    private void UpdateMeteor()
    {
        myMeteor.AddSize();
        myMeteor.AddSpeed();
    }
}
