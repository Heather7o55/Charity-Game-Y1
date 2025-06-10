using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image green;
    public Image red;
    public int ID;
    public Image artwork;
    private CustomerManager.Request request;
    void Start()
    {
        while(true)
        {
            for(int i = 0; i < CustomerManager.requests.Count; i++)
            {
                if(CustomerManager.requests[i].requestID == ID)
                {
                    request = CustomerManager.requests[i];
                    break;
                }
            }
            break;
        }
        artwork.sprite = request.item.artwork;  
    }
    void Update()
    {
        if(green.fillAmount != 1f)
            green.fillAmount += 1.0f / request.timer * Time.deltaTime;
        else if(red.fillAmount != 1f) 
            red.fillAmount += 1.0f / request.timer * Time.deltaTime;
        else
        {
            for(int i = 0; i < CustomerManager.requests.Count; i++)
            {
                if(CustomerManager.requests[i].requestID == request.requestID)
                {
                    UIManager.gameOver = true;
                    CustomerManager.requests.RemoveAt(i);
                }
            }
        }
    }
}
