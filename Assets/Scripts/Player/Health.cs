using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth; //maximum luong mau cua player
    [HideInInspector] public int currentHealth; //mau hien tai

    public HealthBar healthBar; //thanh mau tren UI

    private float safeTime;
    public float safeTimeDuration = 1f;
    public bool isDead = false;

    public bool camShake = false;

    private void Start()
    {
        currentHealth = maxHealth; //set so luong mau ban dau = max

        if (healthBar != null)
            healthBar.UpdateHealth(currentHealth, maxHealth); //update mau ban dau voi gia tri ban dau
    }

    public void TakeDam(int damage)
    {
        if (safeTime <= 0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                if (this.gameObject.tag == "Enemy")
                {
                    FindObjectOfType<WeaponManager>().RemoveEnemyToFireRange(this.transform);
                    FindObjectOfType<Killed>().UpdateKilled();
                    //FindObjectOfType<PlayerExp>().UpdateExperience(UnityEngine.Random.Range(1, 4));
                    Destroy(this.gameObject, 0.125f);
                }
                isDead = true;
            }

            // If player then update health bar
            if (healthBar != null)
                healthBar.UpdateHealth(currentHealth, maxHealth);

            safeTime = safeTimeDuration;
        }
    }

    private void Update()
    {
        if (safeTime > 0)
        {
            safeTime -= Time.deltaTime;
        }
    }
}
