using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update

    public float BulletSpeed; 
    public Transform BulletPrefabSpawn;
    public GameObject BulletPrefab;
    

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, BulletPrefabSpawn.position, Quaternion.identity, GameObject.FindGameObjectWithTag("BulletHolder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(BulletPrefabSpawn.forward * BulletSpeed,ForceMode.Impulse);
    }
}
