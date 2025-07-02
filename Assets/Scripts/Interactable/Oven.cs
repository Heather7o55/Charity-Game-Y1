using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;
public class Oven : Interactable
{
    public override void Interact(Collider col)
    {
        if(Input.GetKey(KeyCode.E))
        {
        }
    }
    void LateUpdate()
    {
        if(!timerActive & ValidateRecipeBool())
        {
            
        }
    }
}