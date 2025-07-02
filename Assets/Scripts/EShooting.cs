using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EShooting : MonoBehaviour
{
    // Start is called before the first frame update
     public float EBulletSpeed; 
    public Transform EBulletPrefabSpawn;
    public GameObject EBulletPrefab;
    PlayerMovement Pm;
    public float EShootingTimer;
    

    void Start()
    {
       EShootingTimer = 2f;
       StartCoroutine(EnemyShoot()); 
    }

    IEnumerator EnemyShoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(EShootingTimer);
             Shoot();
        }
        
         
    }
    

    void Shoot()
    {
        GameObject bullet = Instantiate(EBulletPrefab, EBulletPrefabSpawn.position, Quaternion.identity, GameObject.FindGameObjectWithTag("BulletHolder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(EBulletPrefabSpawn.forward * EBulletSpeed,ForceMode.Impulse);
    }
}
