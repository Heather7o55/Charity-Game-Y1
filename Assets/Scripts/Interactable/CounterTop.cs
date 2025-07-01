using System.Collections.Generic;
using UnityEngine;

public class CounterTop : Interactable
{
    public Item knife;
    public override void Interact(Collider col)
    {
        if(Input.GetKey(KeyCode.E))
        {
            if(ValidatePlayerItem()) internalItems.Add(PlayerHolding.currentlyHeldItem);
            Item tmpItem = ValidateRecipe();
            /* this is gross to look at, but what it does is check if the items on the counter currently make a recipe, if they don't, 
            it then either gives the player an item back from the counter top, or gives them nothing. 
            If it does make a recipe it gives the player that recipe.*/
            PlayerHolding.currentlyHeldItem = (tmpItem == empty) ? ((internalItems[0] != null) ? internalItems[internalItems.Count - 1] : empty) : tmpItem;
        }
    }
}
