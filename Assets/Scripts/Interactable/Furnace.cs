using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;
public class Furnace : BaseInteractable
{
    private Item internalItem;
    // Interact is called every physics update, serving the same function for interactables as update does in other scripts
    public void Start()
    {
        internalItem = empty;
    }
    public override void Interact(Collider col)
    {
        if(Input.GetKey(KeyCode.E))
        { 
            if(PlayerHolding.currentlyHeldItem == internalItem) return;
            if(ValidatePlayerItem(PlayerHolding.currentlyHeldItem))
            {
                (PlayerHolding.currentlyHeldItem, internalItem) = (internalItem, PlayerHolding.currentlyHeldItem);
                StartCoroutine(StartTimer(interactableTimer));
            }
            else return;
        }
    }
    public void Update()
    {   
        // We do this in update as this logic needs to run independently of when the player is interacting with the object 
        if(internalItem == empty || internalItem == sludge || !ValidatePlayerItem(internalItem))
        {
            timerActive = false;
            return;
        } 
        if(timerActive) return;
        else 
        {
            internalItem = internalItem.nextState;
            
        }
    }

}
