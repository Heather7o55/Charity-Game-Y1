using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;
public class Oven : Interactable
{
    private bool firstStageComplete = false;
    public override void Interact(Collider col)
    {
        if(Input.GetKey(KeyCode.E) & PlayerHolding.currentlyHeldItem == empty)
        {
            PlayerHolding.currentlyHeldItem = (internalItems[internalItems.Count - 1] != null) ? internalItems[internalItems.Count - 1] : empty;
            if(timerActive)
            {
                timerActive = false;
                firstStageComplete = false;
            }
        }
    }
    void LateUpdate()
    {
        if(!timerActive & ValidateRecipeBool())
        {
            if(firstStageComplete)
            {
                Item tmp = ValidateRecipe();
                internalItems.Clear();
                internalItems.Add(tmp);
            }
        }
        if(timerActive && !firstStageComplete) firstStageComplete = true;
    }
}