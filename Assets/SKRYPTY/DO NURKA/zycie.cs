using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zycie : MonoBehaviour
{
    
    private Animator animator;
    public GameObject deathEffect;

    public int health;
    public int liczbaserc;

    public Image[] serce;
    public Sprite pelne;
    public Sprite puste;


    void Update()
    {
        if(health > liczbaserc)
        {
            health = liczbaserc;
        }

        for (int i = 0; i < serce.Length; i++)
        {
            if (i < health)
            {
                serce[i].sprite = pelne;
            }
            else
            {
                serce[i].sprite = puste;
            }

            if (i < liczbaserc)
            {
                serce[i].enabled = true;
            }
            else
            {
                serce[i].enabled = false;
            }
        }
    }
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