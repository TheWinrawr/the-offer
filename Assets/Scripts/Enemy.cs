using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPfb;
    public float fireRate = 2f;

    private float fireRateCooldown;

    private void Update() {
        if (fireRateCooldown <= 0) {
            Fire();
            fireRateCooldown = 2f;
        } else {
            fireRateCooldown -= Time.deltaTime;
        }
    }

    private void Fire() {
        for (int i = 0; i < 8; i++) {
            float angle = i * 360 / 8;
            GameObject bulletObj = Instantiate(bulletPfb, transform.position, Quaternion.identity);
            IBulletMovement bullet = bulletObj.GetComponent<IBulletMovement>();
            bullet.Speed = 5f;
            bullet.Angle = angle;
        }
    }
}
