using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
public class CustomerTable : Interactable
{

    public override void Interact(Collider col)
    {
        if(col.CompareTag("PBullet"))
        {
            if(col.gameObject.GetComponent<PlayerBullet>().item == empty) return;
            internalItems.Add(col.gameObject.GetComponent<PlayerBullet>().item);
            Destroy(col);
        }
    }
    void LateUpdate()
    {
        // We run this in LateUpdate as it makes sure that all item transfers occur before this gets called
        CheckValidItem();
    }
    private void CheckValidItem()
    {
        // MISERY NIGHTMARE FUNCTION T-T
        int requestOverSoonest = -1;
        float timeLeft = 0f;
        int item = -1;
        List<int> items = new List<int>();
        for(int i = 0; i < CustomerManager.requests.Count; i++)
        {
            for(int j = 0; j < internalItems.Count; j++)
            {
                if(CustomerManager.requests[i].item == internalItems[j])
                {   
                    if(item == -1) item = j;
                    if(item == j) items.Add(i);
                }
            }
        }
        for(int i = 0; i < items.Count; i++)
        {
            if((CustomerManager.requests[items[i]].timerActive / CustomerManager.requests[items[i]].timer) >= timeLeft)
            {
                timeLeft = CustomerManager.requests[items[i]].timerActive / CustomerManager.requests[items[i]].timer;
                requestOverSoonest = items[i];
            } 
        }
        if(requestOverSoonest != -1)
        {
            CustomerManager.requests.RemoveAt(requestOverSoonest);
            internalItems.RemoveAt(item);
        }
    }
}
