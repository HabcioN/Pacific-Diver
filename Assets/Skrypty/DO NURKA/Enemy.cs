using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private Animator anim;
    public GameObject deathEffect;
    private bool isDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //anim.enabled = true;
    }

    public void TakeDamage (int damage)
    {
        
        health -= damage;
        if (health <= 0)
        {
            anim.Play("smierc");
        }
    }

    private void Update()
    {
        if (!isDead && anim.GetCurrentAnimatorStateInfo(0).IsName("smierc"))
        {
            isDead = true;
            StartCoroutine(DieAfterAnimation());
        }
    }

    IEnumerator DieAfterAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
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
    
    //private void Update()
    //{
        // SprawdŸ, czy obiekt siê porusza
        //bool poruszaSie = (GetComponent<Rigidbody2D>().velocity.magnitude > 0);

        // Jeœli obiekt siê porusza, odpal animacjê "chodzenie"
        //if (poruszaSie)
        //{
            //anim.Play("chodzenie");
        //}
    //}
}
