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
    

    void Start()
    {
       StartCoroutine(EnemyShoot()); 
    }

    IEnumerator EnemyShoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
             Shoot();
        }
        
         
    }
    

    void Shoot()
    {
        GameObject bullet = Instantiate(EBulletPrefab, EBulletPrefabSpawn.position, Quaternion.identity, GameObject.FindGameObjectWithTag("BulletHolder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(EBulletPrefabSpawn.forward * EBulletSpeed,ForceMode.Impulse);
    }
}
