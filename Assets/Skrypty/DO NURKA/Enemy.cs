using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private Animator anim;
    public GameObject deathEffect;
    private bool isDead = false;
    private Rigidbody2D rb;
    private RigidbodyConstraints2D originalConstraints;
    public Transform gracz;
    public float odlegloscMinimalna = 10f;
    public int punktyDodatkowe = 100;
    private punkty1 punktyScript;
    private bool isPlayerInRange = false;
    public int damagePerSecond = 1;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        originalConstraints = rb.constraints;
        punktyScript = FindObjectOfType<punkty1>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.Play("smierc");
            if (punktyScript != null)
            {
                punktyScript.AddPoints(punktyDodatkowe);
            }
        }
    }

    void Update()
    {
        if (!isDead && anim.GetCurrentAnimatorStateInfo(0).IsName("smierc"))
        {
            isDead = true;
            StartCoroutine(DieAfterAnimation());
        }

        if (gracz != null)
        {
            Vector3 kierunek = gracz.position - transform.position;
            kierunek.y = 0f;

            // Sprawd� czy gracz jest po prawej stronie postaci
            if (Vector3.Dot(kierunek, transform.right) > 0 && kierunek.magnitude > odlegloscMinimalna)
            {
                transform.Rotate(0f, 180f, 0f);
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

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        zycie gracz = hitInfo.GetComponent<zycie>();
        if (gracz != null)
        {
            isPlayerInRange = true;
            
            StartCoroutine(DealDamageOverTime(gracz));
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        zycie gracz = hitInfo.GetComponent<zycie>();
        if (gracz != null)
        {
            isPlayerInRange = false;
        }
    }

    IEnumerator DealDamageOverTime(zycie gracz)
    {
        while (isPlayerInRange)
        {
            anim.Play("atak");
            gracz.TakeDamage(damagePerSecond);
            yield return new WaitForSeconds(2f); // Zadawanie obra�e� co sekund�
        }
    }


}
