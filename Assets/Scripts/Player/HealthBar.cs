using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText; //text hien thi mau
    public Image bar; //image fill theo chieu ngang (dai/ngan) hien thi thanh mau mau do

    public void UpdateHealth(int health, int maxHealth) //ham update mau
    {
        healthText.text = health.ToString() + " / " + maxHealth.ToString();
        bar.fillAmount = (float)health / (float)maxHealth;
    }

    public void UpdateBar(int value, int maxValue, string text) // ham update status hinhf anh cua thanh mau
    {
        healthText.text = text;
        bar.fillAmount = (float)value / (float)maxValue;
    }
}
