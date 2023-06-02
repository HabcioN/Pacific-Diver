using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;
    void Start()
    {
        rb.velocity = transform.right * speed;
        DestroyAfterDelay(5f);
        rb.gravityScale = 0.5f;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        
        Destroy(gameObject);
        }
        


    }
    private void DestroyAfterDelay(float delay)
    {
        Destroy(gameObject, delay);
    }

}
