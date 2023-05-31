using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zycie : MonoBehaviour
{
    public int health = 100;
    private Animator animator;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
    
        Destroy(gameObject);
        
    }
}