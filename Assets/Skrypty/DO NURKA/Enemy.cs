using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private Animator anim;
    public GameObject deathEffect;
    private bool isDead = false;
    private Rigidbody2D rb;
    private RigidbodyConstraints2D originalConstraints;
    public Transform gracz;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //anim.enabled = true;
        rb = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        originalConstraints = rb.constraints; ;
        StartCoroutine(ObserwujPozycjeGracza());
    }

    public void TakeDamage (int damage)
    {
        
        health -= damage;
        if (health <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.Play("smierc");
        }
    }

    void Update()
    {
        if (!isDead && anim.GetCurrentAnimatorStateInfo(0).IsName("smierc"))
        {
            isDead = true;
            StartCoroutine(DieAfterAnimation());
        }

    }

    IEnumerator ObserwujPozycjeGracza()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(0.1f); // Sprawdzaj pozycjê gracza co pó³ sekundy

            if (gracz != null)
            {
                Vector3 kierunek = gracz.position - transform.position;
                kierunek.y = 0f;

                if (kierunek != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(kierunek);
                }
            }
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
