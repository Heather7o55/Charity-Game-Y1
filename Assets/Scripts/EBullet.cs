using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement pm;
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pm = other.GetComponent<PlayerMovement>();
            if(pm != null)
                StartCoroutine(pm.StunnedEffect());
        }
    }

}
    
       
