using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // this script is going to be used to set all the parameters in the separate controller and manager scripts
    public Item empty;
    public Item sludge;
    void Awake()
    {
        CustomerManager.ResetCustomerManager();
        BaseInteractable.empty = empty;
        BaseInteractable.sludge = sludge;
        DifficultyController.difficulty.high = 30;
        DifficultyController.difficulty.low = 20;
    }
}
