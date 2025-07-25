using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public abstract class Interactable : MonoBehaviour
{
    public List<Item> validItems = new List<Item>();
    public float interactableTimer;
    public bool timerActive;
    public List<Item> internalItems = new List<Item>();
    public Recipe.Station station;
    public static Item empty;
    public static Item sludge;
    private void OnTriggerStay(Collider col)
    {
        if(!col.CompareTag("Player") || !col.CompareTag("PBullet")) return;
        // We do this because the triggers will be overlapping between interactables, this ensures the player can only interact with the one they're looking at
        if(!IsBeingLookedAt(col.gameObject) || !col.CompareTag("PBullet")) return;
        Debug.Log("interacting");
        // We pass the collider through as it makes extra checks on the interactables script easier (and well possible lmao)
        Interact(col);
    }
    public bool IsBeingLookedAt(GameObject player)
    {
        // This function sends a ray cast out of the centre of the players camera, and if it collides with this object (the interactable this script is attached to) it returns true.
        Debug.DrawLine(player.transform.position, player.transform.position - Vector3.back);
        if(Physics.Raycast(player.transform.position, player.transform.position - Vector3.back, out RaycastHit hit, Mathf.Infinity))
            return hit.collider.gameObject == gameObject;
        else return false;
    }
    public bool ValidatePlayerItem()
    // We do this here as this is universally used across interactables
    {
        return PlayerHolding.currentlyHeldItem.recipeTables.Any(recipes => recipes.validStations.Any(Station => Station == station));
        // return validItems.Any(Item => Item == item);
    }
    public bool ValidateItem(Item item)
    {
        return item.recipeTables.Any(recipes => recipes.validStations.Any(Station => Station == station));
    }
    public Item ValidateRecipe()
    {
        foreach(Recipe recipe in internalItems[0].recipeTables)
        {
            if(recipe.requirements == internalItems.ToArray())
            {
                Item tmp = recipe.output;
                internalItems.Clear();
                return tmp;
            } 
        }
        return empty;
    }
    public bool ValidateRecipeBool()
    {
        foreach(Recipe recipe in internalItems[0].recipeTables)
        {
            if(recipe.requirements == internalItems.ToArray())
            {
                Item tmp = recipe.output;
                internalItems.Clear();
                return true;
            } 
        }
        return false;
    }
    public IEnumerator StartTimer(float timer)
    {
        // A lot of interactables are going to need timers, hence we have the float, bool, and Enumerator in the BaseInteractable script 
        timerActive = true;
        yield return new WaitForSeconds(timer);
        timerActive = false;
    }
    public abstract void Interact(Collider col);
}
