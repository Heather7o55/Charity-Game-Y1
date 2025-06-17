using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    public float horizontalInput;
    public int moveSpeed = 10;
    void Update()
    {
        UpdateMovement();
    }
    private void UpdateMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-Vector3.right*Time.deltaTime * horizontalInput* moveSpeed) ;
    }
}
