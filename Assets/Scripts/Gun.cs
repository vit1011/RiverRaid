using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private int ammo = 1;

    private void Update() {
       
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            if(ammo > 0){
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletPrefab.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward  * bulletSpeed;
            ammo--;
            }
        }

    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player")
        {
            if(ammo == 0){
            ammo = 1;
            }
        }
    }
}
