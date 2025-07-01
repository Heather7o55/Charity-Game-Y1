using System.Collections;
using System.Collections.Generic;
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
        
        if(other.gameObject.CompareTag("Player"))
        {  
            if(PlayerMovement.ParryActive == false)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                
                GetComponent<Rigidbody>().AddForce(-transform.forward * EBulletSpeed,ForceMode.VelocityChange);
            }
            if(PlayerMovement.ParryActive == true)
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