using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
      private Vector3 moveDirection;
      public float horizontalInput;
      public int moveSpeed = 10;
      static bool Stunned = true;
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        if (Stunned == true)
        {
             horizontalInput = Input.GetAxis("Horizontal");
             transform.Translate(-Vector3.right*Time.deltaTime * horizontalInput* moveSpeed);
        }
       

    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EBullet"))
        {
            StunnedEffect();
        }
    }

    public IEnumerator StunnedEffect()
    {
        Stunned = false;
        yield return new WaitForSeconds(2);
        Stunned = true;
        moveSpeed = moveSpeed/2;
        yield return new WaitForSeconds(2);
        moveSpeed = moveSpeed*2;

    }
     

    
}
