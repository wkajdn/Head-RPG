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
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� ��
        {
            TakeDamage(10); // 10��ŭ�� ���ظ� ����
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