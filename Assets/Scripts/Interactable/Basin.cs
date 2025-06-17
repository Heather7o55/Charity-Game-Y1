using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Basin : BaseInteractable
{
    public Item item;
    public override void Interact(Collider col)
    {
        // as stated before interact runs every physics tick so we can in effect use it as a sudo-update, in this case we just  check if the player is holding E and if they are give them the item in the crate.
        if(!Input.GetKey(KeyCode.E)) return;
        if(!ValidatePlayerItem(PlayerHolding.currentlyHeldItem)) return;
        Item localItem = PlayerHolding.currentlyHeldItem;
        foreach(Recipe recipe in localItem.recipes)
        {
            if(recipe.requirements.Length > 2) break;
            if(recipe.stations.Any(Station => Station == station))
            {
                if((recipe.requirements[0] == item || recipe.requirements[0] == PlayerHolding.currentlyHeldItem) && 
                    (recipe.requirements[1] == item || recipe.requirements[1] == PlayerHolding.currentlyHeldItem))
                        PlayerHolding.currentlyHeldItem = recipe.output;
            }
        }
    }
}