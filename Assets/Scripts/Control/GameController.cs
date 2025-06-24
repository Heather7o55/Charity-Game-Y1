using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // this script is going to be used to set all the parameters in the separate controller and manager scripts
    public Item empty;
    public Item sludge;
    public Item[] validItems;
    void Awake()
    {
        CustomerManager.ResetCustomerManager();
        Interactable.empty = empty;
        Interactable.sludge = sludge;
        DifficultyController.difficulty.high = 30;
        DifficultyController.difficulty.low = 20;
        foreach(Item i in validItems)
        {
            CustomerManager.validItems.Add(i);
        }
    }
}
