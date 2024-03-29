using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile; //bullet
    public GameObject muzzle; //tia lua dau sung
    public Transform[] spawnPos; //pos spawn bullet
    private float timeBtwShots;
    public float startTimeBtwShots; //khoang time giua cac lan soawn bullet
    public float bulletForce;
    public int minDamage = 6;
    public int maxDamage = 16;

    // Effect Part 10
    public GameObject fireEffect;

    public WeaponManager weaponManager;
    public Transform calculatePoint;


    private void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
    }


    private void Update()
    {
        //UPDATE
        timeBtwShots -= Time.deltaTime;
        if (timeBtwShots <= 0)
        {
            Transform enemy = weaponManager.FindNearestEnemy(calculatePoint.position);
            if (enemy != null)
            {
                RotateGun(enemy.position);
                Fire();
            }
            //RotateGun(new Vector3(3,3,3));
            //Fire();
        }
    }


    void RotateGun(Vector3 pos) //ham xoay sung target enemy
    {
        Vector2 lookDir = pos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        } 
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }

    void Fire() //ham ban sung
    {
        // For is for auto fire part
        foreach (Transform spanw in spawnPos)
        {
            Instantiate(muzzle, spanw.position, transform.rotation, transform);//tao tia lua
            var bullet = Instantiate(projectile, spanw.position, Quaternion.identity);//spawn dan
            Bullet bulletC = bullet.GetComponent<Bullet>();
            bulletC.minDamage = minDamage;
            bulletC.maxDamage = maxDamage;

            timeBtwShots = startTimeBtwShots;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);

            //Part 10
            var fireE = Instantiate(fireEffect, spanw.position, transform.rotation, transform);
        }
    }



}
