using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public abstract class BaseInteractable : MonoBehaviour
{
    public List<Item> validItems = new List<Item>();
    public float interactableTimer;
    public bool timerActive;
    public static Item empty;
    public static Item sludge;
    private void OnTriggerStay(Collider col)
    {
        if(!col.CompareTag("Player")) return;
        // We do this because the triggers will be overlapping between interactables, this ensures the player can only interact with the one they're looking at
        if(!IsBeingLookedAt()) return;
        // We pass the collider through as it makes extra checks on the interactables script easier (and well possible lmao)
        Interact(col);
    }
    public bool IsBeingLookedAt()
    {
        // This function sends a ray cast out of the centre of the players camera, and if it collides with this object (the interactable this script is attached to) it returns true.
        Ray CameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(CameraRay, out RaycastHit hit))
            return hit.collider.gameObject == gameObject;
        else return false;
    }
    public bool ValidatePlayerItem(Item item)
    // We do this here as this is universally used across interactables
    {
        return validItems.Any(Item => Item == item);
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
