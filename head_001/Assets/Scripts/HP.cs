using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;

    public Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 시
        {
            TakeDamage(10); // 10만큼의 피해를 입힘
        }
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= (int)damageAmount;

        UpdateHealthSlider();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Monster died");
    }
}