using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpiders : MonoBehaviour
{
    public GameObject spiderBulletPfb;
    public float fireRate = 0.5f;
    public float speed = 5f;

    private float fireRateCooldown;

    private void Update() {
        if (fireRateCooldown <= 0) {
            Fire();
            fireRateCooldown = fireRate;
        } else {
            fireRateCooldown -= Time.deltaTime;
        }
    }

    private void Fire() {
        float angle = Random.Range(0, 360);
        GameObject bulletObj = Instantiate(spiderBulletPfb, transform.position, Quaternion.identity);
        IBulletMovement bullet = bulletObj.GetComponent<IBulletMovement>();
        bullet.Speed = speed;
        bullet.Angle = angle;
    }
}
