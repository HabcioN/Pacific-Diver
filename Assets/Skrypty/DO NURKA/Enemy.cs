using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private Animator anim;
    public GameObject deathEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage (int damage)
    {
        
        health -= damage;
        if (health <= 0)
        {
            anim.Play("smierc");
            Die();
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
        anim.SetTrigger("Die");
    }
    public int damage = 25;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        zycie gracz = hitInfo.GetComponent<zycie>();
        if (gracz != null)
        {
            anim.Play("atak");
            gracz.TakeDamage(damage);
        }
        
    }
    
    private void Update()
    {
        // SprawdŸ, czy obiekt siê porusza
        bool poruszaSie = (GetComponent<Rigidbody2D>().velocity.magnitude > 0);

        // Jeœli obiekt siê porusza, odpal animacjê "chodzenie"
        if (poruszaSie)
        {
            anim.Play("chodzenie");
        }
    }
}
