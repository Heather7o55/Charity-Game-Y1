using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement pm;
    public GameObject ParrySpot;
    public float EBulletSpeed = 30f; 

    void Start()
    {
        ParrySpot = GameObject.FindWithTag("ParrySpot");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {  
            if (PlayerMovement.ParryActive)
            {
                GetComponent<Rigidbody>().AddForce(ParrySpot.transform.forward * EBulletSpeed,ForceMode.Impulse);
            }
            if (!PlayerMovement.ParryActive)
            {
                pm = other.GetComponent<PlayerMovement>();
                if(pm != null)
                {
                StartCoroutine(pm.StunnedEffect());  
                }
            }
            else
            return;
            
        }
    }
}