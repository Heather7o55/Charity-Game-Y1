using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Oven : Interactable
{
    // Interact is called every physics update, serving the same function for interactables as update does in other scripts
    public override void Interact(Collider col)
    {
        if(Input.GetKey(KeyCode.E))
        {

        }
    }
}