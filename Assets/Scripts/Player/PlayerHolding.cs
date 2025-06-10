using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHolding : MonoBehaviour
{
    public static Item currentlyHeldItem;
    public GameObject playerArm;
    public Transform spawnPoint;
    private GameObject heldItemObject;
    public Item empty;
    // We have to use a dedicated "empty" item as unity throws a fit if i set it to null
    void Start()
    {
        currentlyHeldItem = empty;
    }
    void Update()
    {
        // This script checks if the players hand is empty and if it isn't loads the model attached to the item
        if(currentlyHeldItem == empty) 
        {
            playerArm.SetActive(false);
            return;
        }
        playerArm.SetActive(true);
        if(!heldItemObject == currentlyHeldItem.model)
        {
            Destroy(heldItemObject);
            heldItemObject = Instantiate(currentlyHeldItem.model, spawnPoint);
        }
    }
}
