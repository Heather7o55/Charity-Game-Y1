using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    private bool timerActive = false;
    public GameObject customerGObj;
    void Update()
    {
        if(timerActive) return;
        else 
            StartCoroutine(SpawnCustomer(GenerateTimer()));
    }
    public void SpawnCustomer()
    {
        Debug.Log("spawned customer");
        Instantiate(customerGObj, transform);
    }
    private float GenerateTimer()
    {
        return Random.Range(DifficultyController.difficulty.low ,DifficultyController.difficulty.high) * 0.5f;
    }
    private IEnumerator SpawnCustomer(float timer)
    {
        timerActive = true;
        yield return new WaitForSeconds(timer);
        SpawnCustomer();
        timerActive = false;
    }
}
