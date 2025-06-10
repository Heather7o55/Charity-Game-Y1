using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basin : BaseInteractable
{
    public Item item;
    public Item acceptedItem;
    public override void Interact(Collider col)
    {
        // as stated before interact runs every physics tick so we can in effect use it as a sudo-update, in this case we just  check if the player is holding E and if they are give them the item in the crate.
        if(Input.GetKey(KeyCode.E))
        {
            if(PlayerHolding.currentlyHeldItem != item && PlayerHolding.currentlyHeldItem == acceptedItem) PlayerHolding.currentlyHeldItem = item;
        }
    }
}
