using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // New Part Level up Weapon
    public List<Transform> weaponSlots = new List<Transform>(); //list slot pos spawn bullet
    public List<Transform> Enemies = new List<Transform>(); // list enemy trong tam ban cua player

    int currentWeaponSlot = 0;

    public void AddWeapon(GameObject weaponPrefab) //spawn 
    {
        if (currentWeaponSlot < weaponSlots.Count)
        {
            Instantiate(weaponPrefab, weaponSlots[currentWeaponSlot]);
            currentWeaponSlot++;
        }
    }


    public void AddEnemyToFireRange(Transform transform) //add nhunwg enemy nam trong khoang dc ban vao list
    {
        Health enemyHealth = transform.GetComponent<Health>();
        if (!enemyHealth.isDead)
            Enemies.Add(transform);
    }

    public void RemoveEnemyToFireRange(Transform transform)
    {
        Enemies.Remove(transform);
    }

    public Transform FindNearestEnemy(Vector2 weaponPos) //tinh toan xem anemy nao gan player nhat thi se ban truoc
    {
        if (Enemies != null && Enemies.Count <= 0) return null;
        Transform nearestEnemy = Enemies[0];
        foreach (Transform enemy in Enemies)
        {
            // duyet qua mang Enemies
            // neu khoang cach tu tung enemy nho hon khoang cach cua enemy dau tien, thi enemy gan nhat dc set lai
            // con neu k co thi enemy gan nhat la enemy dau tien trong mang
            if (Vector2.Distance(enemy.position, weaponPos) < Vector2.Distance(nearestEnemy.position, weaponPos))
            {
                nearestEnemy = enemy;

            }
        }

        return nearestEnemy;
    }




}
