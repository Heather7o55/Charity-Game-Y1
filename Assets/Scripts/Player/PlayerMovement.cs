using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    public float horizontalInput;
    public int moveSpeed = 10;
    static bool Stunned = true;
    public static bool ParryActive;
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
            Parry();
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
    public IEnumerator Parry()
    {
        ParryActive = true;
        yield return new WaitForSeconds(1);
        ParryActive = false;
    }
}
