using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public SpriteRenderer spriteRenderer;
    public Sprite damagedSprite;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Change sprite to damaged sprite
        if (spriteRenderer != null && damagedSprite != null)
        {
            spriteRenderer.sprite = damagedSprite;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform any death actions here, such as playing death animation, sound, etc.
        Destroy(gameObject);
        SceneManager.LoadScene("Fim");
    }
}