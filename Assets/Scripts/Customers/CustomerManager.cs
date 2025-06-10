using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
// I don't feel like this script is bad anymore, this is a perfectly reasonable script to make.
public class CustomerManager : MonoBehaviour
{
    // I declare valid items here as it makes sense to the requests for what items are valid be made here
    public static List<Item> validItems = new List<Item>();
    public static List<GameObject> orderUIList = new List<GameObject>();
    public struct Request
    {
        public float timer;
        public float timerActive;
        public Item item;
        public int requestID;
    }
    public static List<Request> requests = new List<Request>();
    public static void ResetCustomerManager()
    {
        orderUIList.Clear();
        requests.Clear();
    }
    public static int CustomerRequest()
    {
        Request request;
        int ID;
        // I use range here to pick a random number within the valid items list, which makes sure that customers can only request an item the player can make
        request.item = validItems[Random.Range(0, validItems.Count)];
        request.timer = Random.Range(DifficultyController.difficulty.low, DifficultyController.difficulty.high);
        while(true)
        {
            // this while loop makes sure that we don't get any duped IDs, i mean its unlikely anyway but for safety
            ID = Random.Range(0, 1000);
            if(!requests.Any(Request => Request.requestID == ID)) break;
        }
        request.requestID = ID;
        request.timerActive = 0f;
        requests.Add(request);
        return ID;
    }
    public static void UpdatedRequestTimer(int ID)
    {
        for(int i = 0; i < requests.Count; i++)
            {
                if(requests[i].requestID == ID)
                {
                    Request request = requests[i];
                    request.timerActive += 0.5f * Time.deltaTime;
                    Debug.Log(request.timerActive * 2);
                    requests[i] = request;
                    break;
                }
            }
    }

}