using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrate : BaseInteractable
{
    public Item item;
    public override void Interact(Collider col)
    {
        // as stated before interact runs every physics tick so we can in effect use it as a sudo-update, in this case we just  check if the player is holding E and if they are give them the item in the crate.
        if(Input.GetKey(KeyCode.E))
        {
            if(PlayerHolding.currentlyHeldItem != item) PlayerHolding.currentlyHeldItem = item;
        }
    }
    void Awake()
    {
        /* It makes sense to add every single item in an item crate to the valid items list, as it would be pointless to have an item crate which interactables refuse to take as its invalid, 
        this just prevents that use error bug */
        CustomerManager.validItems.Add(item);
    }

}
