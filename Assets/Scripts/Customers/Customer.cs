using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private int ID;
    private GameObject orderUI;
    private bool requestActive = false;
    void Start()
    {
        ID = CustomerManager.CustomerRequest();
        // This just runs on start as we Instantiate the customer in a separate script so it can just make a request when its started
        orderUI = UIManager.CreateOrderUI(ID);
        requestActive = true;
    }
    private bool IfRequestFulfilled()
    {
        /* For those unaware, return returns the output of the given variable, 
        in this case since my return type is bool and the return type of that function call is also a bool i can just return the function, 
        as it returns the output of the function */
        return !CustomerManager.requests.Any(request => request.requestID == ID);
    }
    void Update()
    {
        CustomerManager.UpdatedRequestTimer(ID);
        /* We call this in update as running this next frame shouldn't pose any issues, 
        but running it on lateUpdate could cause it to run before CustomerTable's check making dupes possible */
        if(IfRequestFulfilled() && requestActive) 
        {
            // we need to manually remove order UI from the list as otherwise it stays in the list. 
            CustomerManager.orderUIList.Remove(orderUI);
            Destroy(orderUI);
            Destroy(gameObject);
        }
    }
}
