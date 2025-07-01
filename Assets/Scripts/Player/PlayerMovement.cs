using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    public float horizontalInput;
    public int moveSpeed = 10;
    static bool Stunned;
    public static bool ParryActive;
    
    void Start()
    {
        ParryActive = true;
        Stunned = true;
    }
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //ParryActive = false;
            StartCoroutine(Parry()); 
            Debug.Log("Ha");
            
        }
    }
    public IEnumerator StunnedEffect()
    {
        Stunned = false;
        yield return new WaitForSeconds(2);
        Stunned = true;
        moveSpeed /= 2;
        yield return new WaitForSeconds(2);
        moveSpeed *= 2;
    }
     public IEnumerator Parry()
     {
         ParryActive = false;
         yield return new WaitForSeconds(1);
         ParryActive = true;
         StopCoroutine(Parry());
         
     }
}
